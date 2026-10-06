namespace WinAppProyecto2
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabMenu;

        private System.Windows.Forms.TabPage tabCreate;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.TabPage tabList;

        private System.Windows.Forms.FlowLayoutPanel flowCreateButtons;
        private System.Windows.Forms.Button btnPreCube, btnPreSphere, btnPrePyramid, btnPreCylinder, btnPreCone;
        private System.Windows.Forms.Button btnPreLight;
        private System.Windows.Forms.Panel pnlPreviewContainer;
        private System.Windows.Forms.Button btnAddToScene;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblPreviewTitle;

        private System.Windows.Forms.GroupBox grpTransform;
        private System.Windows.Forms.NumericUpDown numPosX, numPosY, numPosZ;
        private System.Windows.Forms.NumericUpDown numRotX, numRotY, numRotZ;
        private System.Windows.Forms.NumericUpDown numSclX, numSclY, numSclZ;

        private System.Windows.Forms.Label lblPos, lblPosX, lblPosY, lblPosZ;
        private System.Windows.Forms.Label lblRot, lblRotX, lblRotY, lblRotZ;
        private System.Windows.Forms.Label lblScl, lblSclX, lblSclY, lblSclZ;

        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.Button btnColorPick;
        private System.Windows.Forms.Label lblRough, lblSpec, lblOpac;
        private System.Windows.Forms.TrackBar trkRoughness, trkSpecular, trkOpacity;

        private System.Windows.Forms.GroupBox grpLightProps;
        private System.Windows.Forms.Label lblLightInt, lblLightRange;
        private System.Windows.Forms.NumericUpDown numLightInt, numLightRange;
        private System.Windows.Forms.Button btnLightColorProp;

        private System.Windows.Forms.ListBox lstObjects;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusAction;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusHelp;
        private System.Windows.Forms.ColorDialog colorDialog1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabCreate = new System.Windows.Forms.TabPage();
            this.flowCreateButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPreCone = new System.Windows.Forms.Button();
            this.btnPreCube = new System.Windows.Forms.Button();
            this.btnPreSphere = new System.Windows.Forms.Button();
            this.btnPrePyramid = new System.Windows.Forms.Button();
            this.btnPreCylinder = new System.Windows.Forms.Button();
            this.btnPreLight = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddToScene = new System.Windows.Forms.Button();
            this.pnlPreviewContainer = new System.Windows.Forms.Panel();
            this.lblPreviewTitle = new System.Windows.Forms.Label();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.grpLightProps = new System.Windows.Forms.GroupBox();
            this.lblLightInt = new System.Windows.Forms.Label();
            this.numLightInt = new System.Windows.Forms.NumericUpDown();
            this.lblLightRange = new System.Windows.Forms.Label();
            this.numLightRange = new System.Windows.Forms.NumericUpDown();
            this.btnLightColorProp = new System.Windows.Forms.Button();
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.btnColorPick = new System.Windows.Forms.Button();
            this.lblRough = new System.Windows.Forms.Label();
            this.trkRoughness = new System.Windows.Forms.TrackBar();
            this.lblSpec = new System.Windows.Forms.Label();
            this.trkSpecular = new System.Windows.Forms.TrackBar();
            this.lblOpac = new System.Windows.Forms.Label();
            this.trkOpacity = new System.Windows.Forms.TrackBar();
            this.grpTransform = new System.Windows.Forms.GroupBox();
            this.lblPos = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.lblPosY = new System.Windows.Forms.Label();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.lblPosZ = new System.Windows.Forms.Label();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.lblRot = new System.Windows.Forms.Label();
            this.lblRotX = new System.Windows.Forms.Label();
            this.numRotX = new System.Windows.Forms.NumericUpDown();
            this.lblRotY = new System.Windows.Forms.Label();
            this.numRotY = new System.Windows.Forms.NumericUpDown();
            this.lblRotZ = new System.Windows.Forms.Label();
            this.numRotZ = new System.Windows.Forms.NumericUpDown();
            this.lblScl = new System.Windows.Forms.Label();
            this.lblSclX = new System.Windows.Forms.Label();
            this.numSclX = new System.Windows.Forms.NumericUpDown();
            this.lblSclY = new System.Windows.Forms.Label();
            this.numSclY = new System.Windows.Forms.NumericUpDown();
            this.lblSclZ = new System.Windows.Forms.Label();
            this.numSclZ = new System.Windows.Forms.NumericUpDown();
            this.tabList = new System.Windows.Forms.TabPage();
            this.lstObjects = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusHelp = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.tabCreate.SuspendLayout();
            this.flowCreateButtons.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.grpLightProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLightInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLightRange)).BeginInit();
            this.grpMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkRoughness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpecular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkOpacity)).BeginInit();
            this.grpTransform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSclX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSclY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSclZ)).BeginInit();
            this.tabList.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabMenu);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(900, 587);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tabCreate);
            this.tabMenu.Controls.Add(this.tabProperties);
            this.tabMenu.Controls.Add(this.tabList);
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Location = new System.Drawing.Point(0, 0);
            this.tabMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(340, 587);
            this.tabMenu.TabIndex = 0;
            // 
            // tabCreate
            // 
            this.tabCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabCreate.Controls.Add(this.flowCreateButtons);
            this.tabCreate.Controls.Add(this.btnDelete);
            this.tabCreate.Controls.Add(this.btnAddToScene);
            this.tabCreate.Controls.Add(this.pnlPreviewContainer);
            this.tabCreate.Controls.Add(this.lblPreviewTitle);
            this.tabCreate.Location = new System.Drawing.Point(4, 22);
            this.tabCreate.Margin = new System.Windows.Forms.Padding(2);
            this.tabCreate.Name = "tabCreate";
            this.tabCreate.Padding = new System.Windows.Forms.Padding(2);
            this.tabCreate.Size = new System.Drawing.Size(332, 561);
            this.tabCreate.TabIndex = 0;
            this.tabCreate.Text = "Crear";
            // 
            // flowCreateButtons
            // 
            this.flowCreateButtons.AutoScroll = true;
            this.flowCreateButtons.Controls.Add(this.btnPreCone);
            this.flowCreateButtons.Controls.Add(this.btnPreCube);
            this.flowCreateButtons.Controls.Add(this.btnPreSphere);
            this.flowCreateButtons.Controls.Add(this.btnPrePyramid);
            this.flowCreateButtons.Controls.Add(this.btnPreCylinder);
            this.flowCreateButtons.Controls.Add(this.btnPreLight);
            this.flowCreateButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowCreateButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowCreateButtons.Location = new System.Drawing.Point(2, 278);
            this.flowCreateButtons.Margin = new System.Windows.Forms.Padding(2);
            this.flowCreateButtons.Name = "flowCreateButtons";
            this.flowCreateButtons.Padding = new System.Windows.Forms.Padding(8);
            this.flowCreateButtons.Size = new System.Drawing.Size(328, 281);
            this.flowCreateButtons.TabIndex = 0;
            this.flowCreateButtons.WrapContents = false;
            // 
            // btnPreCone
            // 
            this.btnPreCone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPreCone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreCone.ForeColor = System.Drawing.Color.White;
            this.btnPreCone.Location = new System.Drawing.Point(58, 16);
            this.btnPreCone.Margin = new System.Windows.Forms.Padding(50, 8, 2, 2);
            this.btnPreCone.Name = "btnPreCone";
            this.btnPreCone.Size = new System.Drawing.Size(210, 32);
            this.btnPreCone.TabIndex = 4;
            this.btnPreCone.Text = "Cono";
            this.btnPreCone.UseVisualStyleBackColor = false;
            // 
            // btnPreCube
            // 
            this.btnPreCube.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPreCube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreCube.ForeColor = System.Drawing.Color.White;
            this.btnPreCube.Location = new System.Drawing.Point(58, 58);
            this.btnPreCube.Margin = new System.Windows.Forms.Padding(50, 8, 2, 2);
            this.btnPreCube.Name = "btnPreCube";
            this.btnPreCube.Size = new System.Drawing.Size(210, 32);
            this.btnPreCube.TabIndex = 0;
            this.btnPreCube.Text = "Cubo";
            this.btnPreCube.UseVisualStyleBackColor = false;
            // 
            // btnPreSphere
            // 
            this.btnPreSphere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPreSphere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreSphere.ForeColor = System.Drawing.Color.White;
            this.btnPreSphere.Location = new System.Drawing.Point(58, 100);
            this.btnPreSphere.Margin = new System.Windows.Forms.Padding(50, 8, 2, 2);
            this.btnPreSphere.Name = "btnPreSphere";
            this.btnPreSphere.Size = new System.Drawing.Size(210, 32);
            this.btnPreSphere.TabIndex = 1;
            this.btnPreSphere.Text = "Esfera";
            this.btnPreSphere.UseVisualStyleBackColor = false;
            // 
            // btnPrePyramid
            // 
            this.btnPrePyramid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPrePyramid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrePyramid.ForeColor = System.Drawing.Color.White;
            this.btnPrePyramid.Location = new System.Drawing.Point(58, 142);
            this.btnPrePyramid.Margin = new System.Windows.Forms.Padding(50, 8, 2, 2);
            this.btnPrePyramid.Name = "btnPrePyramid";
            this.btnPrePyramid.Size = new System.Drawing.Size(210, 32);
            this.btnPrePyramid.TabIndex = 2;
            this.btnPrePyramid.Text = "Pirámide";
            this.btnPrePyramid.UseVisualStyleBackColor = false;
            // 
            // btnPreCylinder
            // 
            this.btnPreCylinder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPreCylinder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreCylinder.ForeColor = System.Drawing.Color.White;
            this.btnPreCylinder.Location = new System.Drawing.Point(58, 184);
            this.btnPreCylinder.Margin = new System.Windows.Forms.Padding(50, 8, 2, 2);
            this.btnPreCylinder.Name = "btnPreCylinder";
            this.btnPreCylinder.Size = new System.Drawing.Size(210, 32);
            this.btnPreCylinder.TabIndex = 3;
            this.btnPreCylinder.Text = "Cilindro";
            this.btnPreCylinder.UseVisualStyleBackColor = false;
            // 
            // btnPreLight
            // 
            this.btnPreLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(0)))));
            this.btnPreLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreLight.ForeColor = System.Drawing.Color.Yellow;
            this.btnPreLight.Location = new System.Drawing.Point(58, 226);
            this.btnPreLight.Margin = new System.Windows.Forms.Padding(50, 8, 2, 2);
            this.btnPreLight.Name = "btnPreLight";
            this.btnPreLight.Size = new System.Drawing.Size(210, 32);
            this.btnPreLight.TabIndex = 5;
            this.btnPreLight.Text = "Luz (Puntual)";
            this.btnPreLight.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Maroon;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(2, 246);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(328, 32);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "BORRAR SELECCIONADO";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAddToScene
            // 
            this.btnAddToScene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddToScene.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddToScene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToScene.ForeColor = System.Drawing.Color.White;
            this.btnAddToScene.Location = new System.Drawing.Point(2, 205);
            this.btnAddToScene.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddToScene.Name = "btnAddToScene";
            this.btnAddToScene.Size = new System.Drawing.Size(328, 41);
            this.btnAddToScene.TabIndex = 2;
            this.btnAddToScene.Text = "AÑADIR A ESCENA";
            this.btnAddToScene.UseVisualStyleBackColor = false;
            // 
            // pnlPreviewContainer
            // 
            this.pnlPreviewContainer.BackColor = System.Drawing.Color.Black;
            this.pnlPreviewContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPreviewContainer.Location = new System.Drawing.Point(2, 26);
            this.pnlPreviewContainer.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPreviewContainer.Name = "pnlPreviewContainer";
            this.pnlPreviewContainer.Size = new System.Drawing.Size(328, 179);
            this.pnlPreviewContainer.TabIndex = 3;
            // 
            // lblPreviewTitle
            // 
            this.lblPreviewTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPreviewTitle.ForeColor = System.Drawing.Color.White;
            this.lblPreviewTitle.Location = new System.Drawing.Point(2, 2);
            this.lblPreviewTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            this.lblPreviewTitle.Size = new System.Drawing.Size(328, 24);
            this.lblPreviewTitle.TabIndex = 4;
            this.lblPreviewTitle.Text = "Vista Previa";
            this.lblPreviewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabProperties
            // 
            this.tabProperties.AutoScroll = true;
            this.tabProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabProperties.Controls.Add(this.grpLightProps);
            this.tabProperties.Controls.Add(this.grpMaterial);
            this.tabProperties.Controls.Add(this.grpTransform);
            this.tabProperties.Location = new System.Drawing.Point(4, 22);
            this.tabProperties.Margin = new System.Windows.Forms.Padding(2);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Size = new System.Drawing.Size(332, 561);
            this.tabProperties.TabIndex = 1;
            this.tabProperties.Text = "Propiedades";
            // 
            // grpLightProps
            // 
            this.grpLightProps.Controls.Add(this.lblLightInt);
            this.grpLightProps.Controls.Add(this.numLightInt);
            this.grpLightProps.Controls.Add(this.lblLightRange);
            this.grpLightProps.Controls.Add(this.numLightRange);
            this.grpLightProps.Controls.Add(this.btnLightColorProp);
            this.grpLightProps.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLightProps.ForeColor = System.Drawing.Color.White;
            this.grpLightProps.Location = new System.Drawing.Point(0, 495);
            this.grpLightProps.Margin = new System.Windows.Forms.Padding(2);
            this.grpLightProps.Name = "grpLightProps";
            this.grpLightProps.Padding = new System.Windows.Forms.Padding(2);
            this.grpLightProps.Size = new System.Drawing.Size(315, 146);
            this.grpLightProps.TabIndex = 0;
            this.grpLightProps.TabStop = false;
            this.grpLightProps.Text = "Propiedades de Luz";
            this.grpLightProps.Visible = false;
            // 
            // lblLightInt
            // 
            this.lblLightInt.AutoSize = true;
            this.lblLightInt.Location = new System.Drawing.Point(11, 53);
            this.lblLightInt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLightInt.Name = "lblLightInt";
            this.lblLightInt.Size = new System.Drawing.Size(59, 13);
            this.lblLightInt.TabIndex = 0;
            this.lblLightInt.Text = "Intensidad:";
            // 
            // numLightInt
            // 
            this.numLightInt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numLightInt.DecimalPlaces = 2;
            this.numLightInt.ForeColor = System.Drawing.Color.White;
            this.numLightInt.Location = new System.Drawing.Point(11, 69);
            this.numLightInt.Margin = new System.Windows.Forms.Padding(2);
            this.numLightInt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLightInt.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numLightInt.Name = "numLightInt";
            this.numLightInt.Size = new System.Drawing.Size(60, 20);
            this.numLightInt.TabIndex = 1;
            this.numLightInt.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // lblLightRange
            // 
            this.lblLightRange.AutoSize = true;
            this.lblLightRange.Location = new System.Drawing.Point(11, 93);
            this.lblLightRange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLightRange.Name = "lblLightRange";
            this.lblLightRange.Size = new System.Drawing.Size(90, 13);
            this.lblLightRange.TabIndex = 2;
            this.lblLightRange.Text = "Rango (Alcance):";
            // 
            // numLightRange
            // 
            this.numLightRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numLightRange.DecimalPlaces = 2;
            this.numLightRange.ForeColor = System.Drawing.Color.White;
            this.numLightRange.Location = new System.Drawing.Point(11, 110);
            this.numLightRange.Margin = new System.Windows.Forms.Padding(2);
            this.numLightRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLightRange.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numLightRange.Name = "numLightRange";
            this.numLightRange.Size = new System.Drawing.Size(60, 20);
            this.numLightRange.TabIndex = 3;
            this.numLightRange.Value = new decimal(new int[] {
            200,
            0,
            0,
            65536});
            // 
            // btnLightColorProp
            // 
            this.btnLightColorProp.BackColor = System.Drawing.Color.Yellow;
            this.btnLightColorProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLightColorProp.ForeColor = System.Drawing.Color.Black;
            this.btnLightColorProp.Location = new System.Drawing.Point(11, 20);
            this.btnLightColorProp.Margin = new System.Windows.Forms.Padding(2);
            this.btnLightColorProp.Name = "btnLightColorProp";
            this.btnLightColorProp.Size = new System.Drawing.Size(210, 24);
            this.btnLightColorProp.TabIndex = 4;
            this.btnLightColorProp.Text = "Color de Luz";
            this.btnLightColorProp.UseVisualStyleBackColor = false;
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.btnColorPick);
            this.grpMaterial.Controls.Add(this.lblRough);
            this.grpMaterial.Controls.Add(this.trkRoughness);
            this.grpMaterial.Controls.Add(this.lblSpec);
            this.grpMaterial.Controls.Add(this.trkSpecular);
            this.grpMaterial.Controls.Add(this.lblOpac);
            this.grpMaterial.Controls.Add(this.trkOpacity);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.ForeColor = System.Drawing.Color.White;
            this.grpMaterial.Location = new System.Drawing.Point(0, 211);
            this.grpMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Padding = new System.Windows.Forms.Padding(2);
            this.grpMaterial.Size = new System.Drawing.Size(315, 284);
            this.grpMaterial.TabIndex = 1;
            this.grpMaterial.TabStop = false;
            this.grpMaterial.Text = "Material (PBR)";
            // 
            // btnColorPick
            // 
            this.btnColorPick.BackColor = System.Drawing.Color.Gray;
            this.btnColorPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorPick.Location = new System.Drawing.Point(11, 24);
            this.btnColorPick.Margin = new System.Windows.Forms.Padding(2);
            this.btnColorPick.Name = "btnColorPick";
            this.btnColorPick.Size = new System.Drawing.Size(210, 28);
            this.btnColorPick.TabIndex = 0;
            this.btnColorPick.Text = "Color Base";
            this.btnColorPick.UseVisualStyleBackColor = false;
            // 
            // lblRough
            // 
            this.lblRough.AutoSize = true;
            this.lblRough.Location = new System.Drawing.Point(11, 61);
            this.lblRough.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRough.Name = "lblRough";
            this.lblRough.Size = new System.Drawing.Size(168, 13);
            this.lblRough.TabIndex = 1;
            this.lblRough.Text = "Rugosidad (0% Liso - 100% Mate):";
            // 
            // trkRoughness
            // 
            this.trkRoughness.Location = new System.Drawing.Point(11, 77);
            this.trkRoughness.Margin = new System.Windows.Forms.Padding(2);
            this.trkRoughness.Maximum = 100;
            this.trkRoughness.Name = "trkRoughness";
            this.trkRoughness.Size = new System.Drawing.Size(210, 45);
            this.trkRoughness.TabIndex = 2;
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(11, 126);
            this.lblSpec.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(194, 13);
            this.lblSpec.TabIndex = 3;
            this.lblSpec.Text = "Reflectividad (0% Nada - 100% Espejo):";
            // 
            // trkSpecular
            // 
            this.trkSpecular.Location = new System.Drawing.Point(11, 142);
            this.trkSpecular.Margin = new System.Windows.Forms.Padding(2);
            this.trkSpecular.Maximum = 100;
            this.trkSpecular.Name = "trkSpecular";
            this.trkSpecular.Size = new System.Drawing.Size(210, 45);
            this.trkSpecular.TabIndex = 4;
            // 
            // lblOpac
            // 
            this.lblOpac.AutoSize = true;
            this.lblOpac.Location = new System.Drawing.Point(11, 191);
            this.lblOpac.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpac.Name = "lblOpac";
            this.lblOpac.Size = new System.Drawing.Size(187, 13);
            this.lblOpac.TabIndex = 5;
            this.lblOpac.Text = "Opacidad (0% Invisible - 100% Sólido):";
            // 
            // trkOpacity
            // 
            this.trkOpacity.Location = new System.Drawing.Point(11, 207);
            this.trkOpacity.Margin = new System.Windows.Forms.Padding(2);
            this.trkOpacity.Maximum = 100;
            this.trkOpacity.Name = "trkOpacity";
            this.trkOpacity.Size = new System.Drawing.Size(210, 45);
            this.trkOpacity.TabIndex = 6;
            this.trkOpacity.Value = 100;
            // 
            // grpTransform
            // 
            this.grpTransform.Controls.Add(this.lblPos);
            this.grpTransform.Controls.Add(this.lblPosX);
            this.grpTransform.Controls.Add(this.numPosX);
            this.grpTransform.Controls.Add(this.lblPosY);
            this.grpTransform.Controls.Add(this.numPosY);
            this.grpTransform.Controls.Add(this.lblPosZ);
            this.grpTransform.Controls.Add(this.numPosZ);
            this.grpTransform.Controls.Add(this.lblRot);
            this.grpTransform.Controls.Add(this.lblRotX);
            this.grpTransform.Controls.Add(this.numRotX);
            this.grpTransform.Controls.Add(this.lblRotY);
            this.grpTransform.Controls.Add(this.numRotY);
            this.grpTransform.Controls.Add(this.lblRotZ);
            this.grpTransform.Controls.Add(this.numRotZ);
            this.grpTransform.Controls.Add(this.lblScl);
            this.grpTransform.Controls.Add(this.lblSclX);
            this.grpTransform.Controls.Add(this.numSclX);
            this.grpTransform.Controls.Add(this.lblSclY);
            this.grpTransform.Controls.Add(this.numSclY);
            this.grpTransform.Controls.Add(this.lblSclZ);
            this.grpTransform.Controls.Add(this.numSclZ);
            this.grpTransform.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTransform.ForeColor = System.Drawing.Color.White;
            this.grpTransform.Location = new System.Drawing.Point(0, 0);
            this.grpTransform.Margin = new System.Windows.Forms.Padding(2);
            this.grpTransform.Name = "grpTransform";
            this.grpTransform.Padding = new System.Windows.Forms.Padding(2);
            this.grpTransform.Size = new System.Drawing.Size(315, 211);
            this.grpTransform.TabIndex = 2;
            this.grpTransform.TabStop = false;
            this.grpTransform.Text = "Transformación";
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.ForeColor = System.Drawing.Color.Silver;
            this.lblPos.Location = new System.Drawing.Point(11, 32);
            this.lblPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(47, 13);
            this.lblPos.TabIndex = 0;
            this.lblPos.Text = "Posición";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.ForeColor = System.Drawing.Color.Red;
            this.lblPosX.Location = new System.Drawing.Point(11, 53);
            this.lblPosX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(14, 13);
            this.lblPosX.TabIndex = 1;
            this.lblPosX.Text = "X";
            // 
            // numPosX
            // 
            this.numPosX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numPosX.DecimalPlaces = 2;
            this.numPosX.ForeColor = System.Drawing.Color.White;
            this.numPosX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPosX.Location = new System.Drawing.Point(26, 50);
            this.numPosX.Margin = new System.Windows.Forms.Padding(2);
            this.numPosX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosX.Name = "numPosX";
            this.numPosX.Size = new System.Drawing.Size(60, 20);
            this.numPosX.TabIndex = 2;
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.ForeColor = System.Drawing.Color.Green;
            this.lblPosY.Location = new System.Drawing.Point(86, 53);
            this.lblPosY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(14, 13);
            this.lblPosY.TabIndex = 3;
            this.lblPosY.Text = "Y";
            // 
            // numPosY
            // 
            this.numPosY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numPosY.DecimalPlaces = 2;
            this.numPosY.ForeColor = System.Drawing.Color.White;
            this.numPosY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPosY.Location = new System.Drawing.Point(101, 50);
            this.numPosY.Margin = new System.Windows.Forms.Padding(2);
            this.numPosY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosY.Name = "numPosY";
            this.numPosY.Size = new System.Drawing.Size(60, 20);
            this.numPosY.TabIndex = 4;
            // 
            // lblPosZ
            // 
            this.lblPosZ.AutoSize = true;
            this.lblPosZ.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPosZ.Location = new System.Drawing.Point(161, 53);
            this.lblPosZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPosZ.Name = "lblPosZ";
            this.lblPosZ.Size = new System.Drawing.Size(14, 13);
            this.lblPosZ.TabIndex = 5;
            this.lblPosZ.Text = "Z";
            // 
            // numPosZ
            // 
            this.numPosZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numPosZ.DecimalPlaces = 2;
            this.numPosZ.ForeColor = System.Drawing.Color.White;
            this.numPosZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPosZ.Location = new System.Drawing.Point(176, 50);
            this.numPosZ.Margin = new System.Windows.Forms.Padding(2);
            this.numPosZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosZ.Name = "numPosZ";
            this.numPosZ.Size = new System.Drawing.Size(60, 20);
            this.numPosZ.TabIndex = 6;
            // 
            // lblRot
            // 
            this.lblRot.AutoSize = true;
            this.lblRot.ForeColor = System.Drawing.Color.Silver;
            this.lblRot.Location = new System.Drawing.Point(11, 81);
            this.lblRot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRot.Name = "lblRot";
            this.lblRot.Size = new System.Drawing.Size(63, 13);
            this.lblRot.TabIndex = 7;
            this.lblRot.Text = "Rotación (°)";
            // 
            // lblRotX
            // 
            this.lblRotX.AutoSize = true;
            this.lblRotX.ForeColor = System.Drawing.Color.Red;
            this.lblRotX.Location = new System.Drawing.Point(11, 102);
            this.lblRotX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRotX.Name = "lblRotX";
            this.lblRotX.Size = new System.Drawing.Size(14, 13);
            this.lblRotX.TabIndex = 8;
            this.lblRotX.Text = "X";
            // 
            // numRotX
            // 
            this.numRotX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numRotX.DecimalPlaces = 2;
            this.numRotX.ForeColor = System.Drawing.Color.White;
            this.numRotX.Location = new System.Drawing.Point(26, 99);
            this.numRotX.Margin = new System.Windows.Forms.Padding(2);
            this.numRotX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRotX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numRotX.Name = "numRotX";
            this.numRotX.Size = new System.Drawing.Size(60, 20);
            this.numRotX.TabIndex = 9;
            // 
            // lblRotY
            // 
            this.lblRotY.AutoSize = true;
            this.lblRotY.ForeColor = System.Drawing.Color.Green;
            this.lblRotY.Location = new System.Drawing.Point(86, 102);
            this.lblRotY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRotY.Name = "lblRotY";
            this.lblRotY.Size = new System.Drawing.Size(14, 13);
            this.lblRotY.TabIndex = 10;
            this.lblRotY.Text = "Y";
            // 
            // numRotY
            // 
            this.numRotY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numRotY.DecimalPlaces = 2;
            this.numRotY.ForeColor = System.Drawing.Color.White;
            this.numRotY.Location = new System.Drawing.Point(101, 99);
            this.numRotY.Margin = new System.Windows.Forms.Padding(2);
            this.numRotY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRotY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numRotY.Name = "numRotY";
            this.numRotY.Size = new System.Drawing.Size(60, 20);
            this.numRotY.TabIndex = 11;
            // 
            // lblRotZ
            // 
            this.lblRotZ.AutoSize = true;
            this.lblRotZ.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblRotZ.Location = new System.Drawing.Point(161, 102);
            this.lblRotZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRotZ.Name = "lblRotZ";
            this.lblRotZ.Size = new System.Drawing.Size(14, 13);
            this.lblRotZ.TabIndex = 12;
            this.lblRotZ.Text = "Z";
            // 
            // numRotZ
            // 
            this.numRotZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numRotZ.DecimalPlaces = 2;
            this.numRotZ.ForeColor = System.Drawing.Color.White;
            this.numRotZ.Location = new System.Drawing.Point(176, 99);
            this.numRotZ.Margin = new System.Windows.Forms.Padding(2);
            this.numRotZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRotZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numRotZ.Name = "numRotZ";
            this.numRotZ.Size = new System.Drawing.Size(60, 20);
            this.numRotZ.TabIndex = 13;
            // 
            // lblScl
            // 
            this.lblScl.AutoSize = true;
            this.lblScl.ForeColor = System.Drawing.Color.Silver;
            this.lblScl.Location = new System.Drawing.Point(11, 130);
            this.lblScl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScl.Name = "lblScl";
            this.lblScl.Size = new System.Drawing.Size(39, 13);
            this.lblScl.TabIndex = 14;
            this.lblScl.Text = "Escala";
            // 
            // lblSclX
            // 
            this.lblSclX.AutoSize = true;
            this.lblSclX.ForeColor = System.Drawing.Color.Red;
            this.lblSclX.Location = new System.Drawing.Point(11, 150);
            this.lblSclX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSclX.Name = "lblSclX";
            this.lblSclX.Size = new System.Drawing.Size(14, 13);
            this.lblSclX.TabIndex = 15;
            this.lblSclX.Text = "X";
            // 
            // numSclX
            // 
            this.numSclX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numSclX.DecimalPlaces = 2;
            this.numSclX.ForeColor = System.Drawing.Color.White;
            this.numSclX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSclX.Location = new System.Drawing.Point(26, 148);
            this.numSclX.Margin = new System.Windows.Forms.Padding(2);
            this.numSclX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSclX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numSclX.Name = "numSclX";
            this.numSclX.Size = new System.Drawing.Size(60, 20);
            this.numSclX.TabIndex = 16;
            this.numSclX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSclY
            // 
            this.lblSclY.AutoSize = true;
            this.lblSclY.ForeColor = System.Drawing.Color.Green;
            this.lblSclY.Location = new System.Drawing.Point(86, 150);
            this.lblSclY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSclY.Name = "lblSclY";
            this.lblSclY.Size = new System.Drawing.Size(14, 13);
            this.lblSclY.TabIndex = 17;
            this.lblSclY.Text = "Y";
            // 
            // numSclY
            // 
            this.numSclY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numSclY.DecimalPlaces = 2;
            this.numSclY.ForeColor = System.Drawing.Color.White;
            this.numSclY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSclY.Location = new System.Drawing.Point(101, 148);
            this.numSclY.Margin = new System.Windows.Forms.Padding(2);
            this.numSclY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSclY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numSclY.Name = "numSclY";
            this.numSclY.Size = new System.Drawing.Size(60, 20);
            this.numSclY.TabIndex = 18;
            this.numSclY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSclZ
            // 
            this.lblSclZ.AutoSize = true;
            this.lblSclZ.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSclZ.Location = new System.Drawing.Point(161, 150);
            this.lblSclZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSclZ.Name = "lblSclZ";
            this.lblSclZ.Size = new System.Drawing.Size(14, 13);
            this.lblSclZ.TabIndex = 19;
            this.lblSclZ.Text = "Z";
            // 
            // numSclZ
            // 
            this.numSclZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numSclZ.DecimalPlaces = 2;
            this.numSclZ.ForeColor = System.Drawing.Color.White;
            this.numSclZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSclZ.Location = new System.Drawing.Point(176, 148);
            this.numSclZ.Margin = new System.Windows.Forms.Padding(2);
            this.numSclZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSclZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numSclZ.Name = "numSclZ";
            this.numSclZ.Size = new System.Drawing.Size(60, 20);
            this.numSclZ.TabIndex = 20;
            this.numSclZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabList
            // 
            this.tabList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabList.Controls.Add(this.lstObjects);
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Margin = new System.Windows.Forms.Padding(2);
            this.tabList.Name = "tabList";
            this.tabList.Size = new System.Drawing.Size(332, 561);
            this.tabList.TabIndex = 2;
            this.tabList.Text = "Lista Objetos";
            // 
            // lstObjects
            // 
            this.lstObjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstObjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstObjects.ForeColor = System.Drawing.Color.White;
            this.lstObjects.Location = new System.Drawing.Point(0, 0);
            this.lstObjects.Margin = new System.Windows.Forms.Padding(2);
            this.lstObjects.Name = "lstObjects";
            this.lstObjects.Size = new System.Drawing.Size(332, 561);
            this.lstObjects.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusAction,
            this.lblStatusHelp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 587);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(900, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatusAction
            // 
            this.lblStatusAction.ForeColor = System.Drawing.Color.Yellow;
            this.lblStatusAction.Name = "lblStatusAction";
            this.lblStatusAction.Size = new System.Drawing.Size(76, 17);
            this.lblStatusAction.Text = "MODO: IDLE ";
            // 
            // lblStatusHelp
            // 
            this.lblStatusHelp.ForeColor = System.Drawing.Color.White;
            this.lblStatusHelp.Name = "lblStatusHelp";
            this.lblStatusHelp.Size = new System.Drawing.Size(50, 17);
            this.lblStatusHelp.Text = "Ayuda...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 609);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Blender Clone - WinForms Edition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.tabCreate.ResumeLayout(false);
            this.flowCreateButtons.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.grpLightProps.ResumeLayout(false);
            this.grpLightProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLightInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLightRange)).EndInit();
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkRoughness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpecular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkOpacity)).EndInit();
            this.grpTransform.ResumeLayout(false);
            this.grpTransform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSclX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSclY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSclZ)).EndInit();
            this.tabList.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}