using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client {
	public partial class frmMain : Form {
		int sector = 0, col = 3, row = 7, shipAngle = 0, boxCount = 10;
		bool gameOn = false, shieldOn = false;
		UdpUser client = null;
		Pen gridPen = new Pen(System.Drawing.Color.White, 1);
		int gridSize = 0;
		Image planet = Image.FromFile("jupiter.png");
		Image star = Image.FromFile("star.png");
		Image background = Image.FromFile("background.jpg");
		List<Point> points = new List<Point>();
		List<Point> myShipPts = new List<Point>();

		// Structure
		public struct Received {
			public IPEndPoint Sender;
			public string Message;
		}

		// UDP Abstract class
		abstract class UdpBase {
			protected UdpClient Client;

			protected UdpBase() {
				Client = new UdpClient();
			}

			public async Task<Received> Receive() {
				var result = await Client.ReceiveAsync();
				return new Received() {
					Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
					Sender = result.RemoteEndPoint
				};
			}
		}

		// Client
		class UdpUser : UdpBase {
			private UdpUser() { }

			public static UdpUser ConnectTo(string hostname, int port) {
				var connection = new UdpUser();
				connection.Client.Connect(hostname, port);
				return connection;
			}

			public void Send(string message) {
				var datagram = Encoding.ASCII.GetBytes(message);
				Client.Send(datagram, datagram.Length);
			}
		}

		public frmMain() {
			InitializeComponent();

			// set up the grid look - 1 dot, 4 spaces, 1 dot, 4 spaces
			gridPen.DashPattern = new float[] { 1, 4 };
			gridSize = panCanvas.Width / boxCount;

			// Design out my ship... We could just use an image here
			myShipPts.Add(new Point(0, 0));
			myShipPts.Add(new Point(10, 5));
			myShipPts.Add(new Point(0, -20));
			myShipPts.Add(new Point(-10, 5));

		}

		private void beginMessages() {
			if (txtIP.Text.Trim().Length == 0) {
				MessageBox.Show("You must enter the IP address of the server",
									"Connection Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			client = UdpUser.ConnectTo(txtIP.Text.Trim(), 32123);
			client.Send("Connected: " + Environment.UserName);

			// 10.33.7.192

			string msg;
			string[] parts;
			Task.Factory.StartNew(async () => {
				while (true) {
					try {
						msg = (await client.Receive()).Message.ToString();

						parts = msg.Split(':');
						fixParts(parts);
						if (parts[0].Equals("quit")) {
							break;
						} else if (parts[0].Equals("connected")) {
							gameOn = parts[1].Equals("true");

							if (gameOn) {
								txtIP.Invoke(new Action(() => txtIP.BackColor = Color.Green));
								btnConnect.Invoke(new Action(() => btnConnect.BackColor = Color.Green));
								txtIP.Invoke(new Action(() => txtIP.ReadOnly = true));
								txtIP.Invoke(new Action(() => txtIP.Enabled = false));
								btnConnect.Invoke(new Action(() => btnConnect.Enabled = false));

								addText("You have joined the game...\n");
								sector = Convert.ToInt32(parts[2]);
								col = Convert.ToInt32(parts[3]);
								row = Convert.ToInt32(parts[4]);
								lblSector.Invoke(new Action(() => lblSector.Text = "G-" + sector));
							} else {
								addText("Connection not established\n");
								sector = row = col = -1;
							}

							panCanvas.Invoke(new Action(() => panCanvas.Refresh()));

						} else if (parts[0].Equals("block")) {
							int x = gridSize * Convert.ToInt32(parts[1]);
							int y = gridSize * Convert.ToInt32(parts[2]);
							points.Add(new Point(x, y));
							panCanvas.CreateGraphics().FillRectangle(Brushes.Red, x, y, gridSize, gridSize);
						} else {
							addText(msg);
						}
					} catch (Exception e) {
						MessageBox.Show(e.Message);
					}
				}

				Environment.Exit(0);
			});
		}

		private void addText(string msg) {
			txtServerMessages.Invoke(new Action(() => txtServerMessages.ReadOnly = false));
			txtServerMessages.Invoke(new Action(() => txtServerMessages.AppendText(" > " + msg + "\n")));
			txtServerMessages.Invoke(new Action(() => txtServerMessages.ReadOnly = true));
			this.Invoke(new Action(() => this.Focus()));
		}

		private Rectangle loc(double col, double row, double size) {
			double offset = (gridSize - size) / 2;
			return new Rectangle((int)(col * gridSize + offset),
									(int)(row * gridSize + offset),
									(int)size,
									(int)size);
		}

		private void panCanvas_Paint(object sender, PaintEventArgs e) {
			if (chkShowBackground.Checked)
				e.Graphics.DrawImage(background, 0, 0);
			if (chkShowGrid.Checked) {
				// Draw the grid
				for (int i = gridSize; i < panCanvas.Height; i += gridSize) {
					e.Graphics.DrawLine(gridPen, 0, i, panCanvas.Width, i);
					e.Graphics.DrawLine(gridPen, i, 0, i, panCanvas.Height);
				}
			}

			// Place a planet at a random spot
			e.Graphics.DrawImage(planet, loc(4, 5, gridSize / 1.5));

			// Place 5 stars
			e.Graphics.DrawImage(star, loc(1, 3, star.Width / 4));
			e.Graphics.DrawImage(star, loc(2, 9, star.Width / 4));

			if (shieldOn)
				e.Graphics.DrawEllipse(new Pen(Brushes.Gold, 2), loc(col, row, gridSize / 1.5));

			/*
			 * Draw the ship
			 */
			if (gameOn) {
				// scale the drawing larger:
				using (Matrix m = new Matrix()) {
					m.Translate((int)((col + .5) * gridSize), (int)((row + .5) * gridSize));
					m.Rotate(shipAngle);
					m.Scale(.6f, .6f);
					e.Graphics.Transform = m;

					e.Graphics.FillPolygon(new SolidBrush(Color.Red), myShipPts.ToArray());
					e.Graphics.DrawPolygon(Pens.White, myShipPts.ToArray());
				}
			}
		}

		private void btnConnect_Click(object sender, EventArgs e) {
			beginMessages();
		}

		private void btnQuit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private static void fixParts(string[] parts) {
			for (int i = 0; i < parts.Length; i++)
				parts[i] = parts[i].Trim().ToLower();
		}

		private void chkShowBackground_CheckedChanged(object sender, EventArgs e) {
			panCanvas.Refresh();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {

			try {
				switch (keyData) {
					case Keys.Up:
                        if (shipAngle != 0)
                        {
                            shipAngle = 0;
                            panCanvas.Refresh();
                            client.Send("rn");
                        }
                        else {
                            client.Send("mn");
                        }
						break;
					case Keys.Right:
                        if (shipAngle != 90)
                        {
                            shipAngle = 90;
                            panCanvas.Refresh();
                            client.Send("re");
                        }
                        else {
                            client.Send("");
                        }
						break;
					case Keys.Down:
						if (shipAngle != 180) {
							shipAngle = 180;
							panCanvas.Refresh();
							client.Send("rs");
						}
						break;
					case Keys.Left:
						if (shipAngle != 270) {
							shipAngle = 270;
							panCanvas.Refresh();
							client.Send("rw");
						}
						break;
					case Keys.S:
						shieldOn = !shieldOn;
						client.Send("s" + (shieldOn ? "1" : "0"));
						panCanvas.Refresh();
						break;
				}
			} catch (Exception ex) {
				this.Text = ex.Message;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e) {
			if (client != null) client.Send("quit");
		}

		private void chkShowGrid_CheckedChanged(object sender, EventArgs e) {
			panCanvas.Refresh();
		}
	}
}

