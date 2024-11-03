namespace TracertDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.destination = new System.Windows.Forms.TextBox();
            this.startTrace = new System.Windows.Forms.Button();
            this.routeList = new System.Windows.Forms.ListView();
            this.hostIPHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hopHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hostNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.roundTripTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.country2Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ispHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hostApiHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.close = new System.Windows.Forms.Button();
            this.tracert = new VRK.Net.Tracert();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 15);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(153, 20);
            label1.TabIndex = 0;
            label1.Text = "&Host Adress or Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 39);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 20);
            label2.TabIndex = 4;
            label2.Text = "&Route:";
            // 
            // destination
            // 
            this.destination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destination.Location = new System.Drawing.Point(143, 12);
            this.destination.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(751, 27);
            this.destination.TabIndex = 1;
            this.destination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.destination_KeyDown);
            // 
            // startTrace
            // 
            this.startTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startTrace.Location = new System.Drawing.Point(902, 12);
            this.startTrace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.startTrace.Name = "startTrace";
            this.startTrace.Size = new System.Drawing.Size(88, 23);
            this.startTrace.TabIndex = 2;
            this.startTrace.Text = "&Start Trace";
            this.startTrace.UseVisualStyleBackColor = true;
            this.startTrace.Click += new System.EventHandler(this.startTrace_Click);
            // 
            // routeList
            // 
            this.routeList.AllowColumnReorder = true;
            this.routeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hostIPHeader,
            this.hopHeader,
            this.hostNameHeader,
            this.roundTripTimeHeader,
            this.country2Header,
            this.ispHeader,
            this.hostApiHeader});
            this.routeList.GridLines = true;
            this.routeList.HideSelection = false;
            this.routeList.Location = new System.Drawing.Point(13, 57);
            this.routeList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.routeList.Name = "routeList";
            this.routeList.Size = new System.Drawing.Size(995, 527);
            this.routeList.TabIndex = 3;
            this.routeList.UseCompatibleStateImageBehavior = false;
            this.routeList.View = System.Windows.Forms.View.Details;
            // 
            // hostIPHeader
            // 
            this.hostIPHeader.DisplayIndex = 1;
            this.hostIPHeader.Text = "Host";
            this.hostIPHeader.Width = 100;
            // 
            // hopHeader
            // 
            this.hopHeader.DisplayIndex = 0;
            this.hopHeader.Text = "Hop";
            this.hopHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hopHeader.Width = 35;
            // 
            // hostNameHeader
            // 
            this.hostNameHeader.Text = "Host (Native)";
            this.hostNameHeader.Width = 100;
            // 
            // roundTripTimeHeader
            // 
            this.roundTripTimeHeader.Text = "Time";
            this.roundTripTimeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.roundTripTimeHeader.Width = 47;
            // 
            // country2Header
            // 
            this.country2Header.Text = "Country";
            // 
            // ispHeader
            // 
            this.ispHeader.Text = "ISP";
            this.ispHeader.Width = 297;
            // 
            // hostApiHeader
            // 
            this.hostApiHeader.Text = "Host (API)";
            this.hostApiHeader.Width = 346;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(923, 590);
            this.close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(88, 27);
            this.close.TabIndex = 5;
            this.close.Text = "&Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // tracert
            // 
            this.tracert.HostNameOrAddress = null;
            this.tracert.MaxHops = 30;
            this.tracert.TimeOut = 5000;
            this.tracert.Done += new System.EventHandler(this.tracert_Done);
            this.tracert.RouteNodeFound += new System.EventHandler<VRK.Net.RouteNodeFoundEventArgs>(this.tracert_RouteNodeFound);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 629);
            this.Controls.Add(this.close);
            this.Controls.Add(label2);
            this.Controls.Add(this.routeList);
            this.Controls.Add(this.startTrace);
            this.Controls.Add(this.destination);
            this.Controls.Add(label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(720, 360);
            this.Name = "MainForm";
            this.Text = "Traceroute Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Button startTrace;
        private System.Windows.Forms.ListView routeList;
        private VRK.Net.Tracert tracert;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.ColumnHeader hostIPHeader;
        private System.Windows.Forms.ColumnHeader hopHeader;
        private System.Windows.Forms.ColumnHeader hostNameHeader;
        private System.Windows.Forms.ColumnHeader roundTripTimeHeader;
        private System.Windows.Forms.ColumnHeader country2Header;
        private System.Windows.Forms.ColumnHeader ispHeader;
        private System.Windows.Forms.ColumnHeader hostApiHeader;
    }
}

