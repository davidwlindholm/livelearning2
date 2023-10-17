using System;
using System.Windows.Forms;
// import eventargs
using System.Text.RegularExpressions;

public class MainWindow : Form {
    private int currentCell = 0;
    private TextBox[] cells = new TextBox[10];
    private TextBox inputField = new TextBox();
    private Button Enterbtn = new Button();
    private Button Delbtn = new Button();
    private Button Addbtn = new Button();
    private Button Subtractbtn = new Button();
    private Button Multiplybtn = new Button();
    private Button Dividebtn = new Button();

    public MainWindow () {
        // Set form properties
        this.Text = "RPN Calculator";
        this.Size = new System.Drawing.Size(500, 250);
        
        // Stack label
        Label stacklabel = new Label();
        stacklabel.Text = "Stack:";
        stacklabel.Location = new System.Drawing.Point(200, 5);
        stacklabel.Font = new System.Drawing.Font("Roboto", 14);

        //Input label
        Label inputLabel = new Label();
        inputLabel.Text = "Input:";
        inputLabel.Location = new System.Drawing.Point(205, 70);
        inputLabel.Font = new System.Drawing.Font("Roboto", 14);

        //Operations label
        Label operationsLabel = new Label();
        operationsLabel.Text = "Operations:";
        operationsLabel.Location = new System.Drawing.Point(180, 140);
        operationsLabel.Font = new System.Drawing.Font("Roboto", 14);

        // Stack cells
        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        tableLayoutPanel.Location = new System.Drawing.Point(0, 30);
        tableLayoutPanel.Size = new System.Drawing.Size(450, 40);
        tableLayoutPanel.RowCount = 1;
        tableLayoutPanel.ColumnCount = 10;
        for (int i = 0; i < 10; i++) {
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F)); // 10% for each column
        }
        for (int i = 0; i < 10; i++) {
            cells[i] = new TextBox();
            cells[i].ReadOnly = true;
            cells[i].Font = new System.Drawing.Font("Roboto", 12);
            tableLayoutPanel.Controls.Add(cells[i]); // This will add to next available cell automatically
        }
        cells[0].Enabled = true;

        // Input field
        inputField.Location = new System.Drawing.Point(5, 100);
        inputField.Size = new System.Drawing.Size(440, 40);
        inputField.Font = new System.Drawing.Font("Roboto", 14);
        inputField.KeyDown += new KeyEventHandler(EnterKeyPressed);

        // Buttons
        Enterbtn.Text = "\u21B5";
        Enterbtn.Location = new System.Drawing.Point(455, 101);
        Enterbtn.Size = new System.Drawing.Size(35, 30);
        Enterbtn.Font = new System.Drawing.Font("Roboto", 14);
        Enterbtn.Click += new EventHandler(EnterButtonClicked);

        Delbtn.Text = "\u2190";
        Delbtn.Location = new System.Drawing.Point(455, 31);
        Delbtn.Size = new System.Drawing.Size(35, 30);
        Delbtn.Font = new System.Drawing.Font("Roboto", 14);
        Delbtn.Enabled = false;
        Delbtn.Click += new EventHandler(DelButtonClicked);

        Addbtn.Text = "+";
        Addbtn.Location = new System.Drawing.Point(120, 170);
        Addbtn.Size = new System.Drawing.Size(50, 40);
        Addbtn.Font = new System.Drawing.Font("Roboto", 14);
        Addbtn.Enabled = false;
        Addbtn.Click += new EventHandler(OperationButtonClicked);

        Subtractbtn.Text = "-";
        Subtractbtn.Location = new System.Drawing.Point(180, 170);
        Subtractbtn.Size = new System.Drawing.Size(50, 40);
        Subtractbtn.Font = new System.Drawing.Font("Roboto", 14);
        Subtractbtn.Enabled = false;
        Subtractbtn.Click += new EventHandler(OperationButtonClicked);

        Multiplybtn.Text = "*";
        Multiplybtn.Location = new System.Drawing.Point(240, 170);
        Multiplybtn.Size = new System.Drawing.Size(50, 40);
        Multiplybtn.Font = new System.Drawing.Font("Roboto", 14);
        Multiplybtn.Enabled = false;
        Multiplybtn.Click += new EventHandler(OperationButtonClicked);

        Dividebtn.Text = "/";
        Dividebtn.Location = new System.Drawing.Point(300, 170);
        Dividebtn.Size = new System.Drawing.Size(50, 40);
        Dividebtn.Font = new System.Drawing.Font("Roboto", 14);
        Dividebtn.Enabled = false;
        Dividebtn.Click += new EventHandler(OperationButtonClicked);

        // Add everything to the form
        this.Controls.Add(stacklabel);
        this.Controls.Add(tableLayoutPanel);
        this.Controls.Add(Delbtn);
        this.Controls.Add(inputLabel);
        this.Controls.Add(inputField);
        this.Controls.Add(Enterbtn);
        this.Controls.Add(operationsLabel);
        this.Controls.Add(Addbtn);
        this.Controls.Add(Subtractbtn);
        this.Controls.Add(Multiplybtn);
        this.Controls.Add(Dividebtn);

        //check that input is a number
        double num;
        bool isNum = double.TryParse(inputField.Text, out num);
        if (!isNum) {
            inputField.Text = "";
        }
        else {
            //add input to stack
            cells[currentCell].Text = inputField.Text;
            //clear input field
            inputField.Text = "";
            //update current cell
            currentCell++;
            UpdateState();
        }
    }

    private void EnterKeyPressed(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Enter) {
            EnterData();
        }
    }

    private void EnterButtonClicked(object sender, EventArgs e) {
        EnterData();
    }

    private void DelButtonClicked(object sender, EventArgs e) {
        currentCell--;
        cells[currentCell].Text = "";
        UpdateState();
    }

    private void OperationButtonClicked(object sender, EventArgs e) {
        //Determine which button was clicked
        Button button = (Button)sender;
        Calculate(button.Text);
        UpdateState();
    }

    private void EnterData() {
        //check that input is a number
        double num;
        bool isNum = double.TryParse(inputField.Text, out num);
        if (!isNum) {
            inputField.Text = "";
        }
        else {
            //add input to stack
            cells[currentCell].Text = inputField.Text;
            //clear input field
            inputField.Text = "";
            //update current cell
            currentCell++;
            UpdateState();
        }
    }

    private void Calculate(string operation) {
        double num1 = double.Parse(cells[currentCell - 2].Text);
        double num2 = double.Parse(cells[currentCell - 1].Text);

        if (operation == "+") {
            cells[currentCell - 2].Text = (num1 + num2).ToString();
        }
        else if (operation == "-") {
            cells[currentCell - 2].Text = (num1 - num2).ToString();
        }
        else if (operation == "*") {
            cells[currentCell - 2].Text = (num1 * num2).ToString();
        }
        else if (operation == "/") {
            cells[currentCell - 2].Text = (num1 / num2).ToString();
        }

        //clear top cell
        cells[currentCell - 1].Text = "";
        //update current cell
        currentCell--;
    }

    private void UpdateState() {
        //Disable input field and enter buttonif stack is full
        if (currentCell == 10) {
            inputField.Enabled = false;
            Enterbtn.Enabled = false;
        }
        else {
            inputField.Enabled = true;
            Enterbtn.Enabled = true;
        }

        //Disable del button if stack is empty
        if (currentCell == 0) {
            Delbtn.Enabled = false;
        }
        else {
            Delbtn.Enabled = true;
        }

        //Disable operation buttons if stack has less than 2 elements
        if (currentCell < 2) {
            Addbtn.Enabled = false;
            Subtractbtn.Enabled = false;
            Multiplybtn.Enabled = false;
            Dividebtn.Enabled = false;
        }
        else {
            Addbtn.Enabled = true;
            Subtractbtn.Enabled = true;
            Multiplybtn.Enabled = true;
            Dividebtn.Enabled = true;
        }
    }

    private void updateCells(object sender, EventArgs e) {
        TextBox activeCell = (TextBox)sender;
        if (!Regex.IsMatch(activeCell.Text, "^-?\\d*$"))   {
            activeCell.Text = activeCell.Text = "";
        }
        else {
            for (int i = 0; i < 10; i++) {
                if (cells[i].Text == "") {
                    currentCell = i;
                    break;
                }
            }
            //clear and disable cells after current cell
            for (int i = currentCell + 1; i < 10; i++) {
                cells[i].Text = "";
                cells[i].Enabled = false;
            }
            //enable next cell
            if (currentCell <= 9) {
                cells[currentCell].Enabled = true;
            }
        }
    }

    private void Button_Click (object sender, EventArgs e) {
        MessageBox.Show("Button Clicked!");
    }
}
