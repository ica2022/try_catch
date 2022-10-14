using System.Text.RegularExpressions;

namespace PacalaOrganizationalProject
{
    public partial class frmRegistration : Form
    {       string _FullName;
            int _Age;
            long _ContactNo;
            long _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();
        }
                private void frmRegistration_Load(object sender, EventArgs e)
                {
                    
            }
            /////return methods 
            public long StudentNumber(string studNum)
            {

                _StudentNo = long.Parse(studNum);

                return _StudentNo;
            }

            public long ContactNo(string Contact)
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }

                return _ContactNo;
            }

            public string FullName(string LastName, string FirstName, string MiddleInitial)
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }

                return _FullName;
            }

            public int Age(string age)
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }

                return _Age;
            }
            private void btnSubmit_Load(object sender, EventArgs e)
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbProgram.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");


                Form2 frm = new Form2();
                frm.ShowDialog();
            }

        private void frmRegistration_Load_1(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                        "BS Information Technology",
                        "BS Computer Science",
                        "BS Information Systems",
                        "BS in Accountacy",
                        "BS in Hospitality Management",
                        "BS IN Tourism Management",
                    };
                    for (int i = 0; i < 6; i++)
                    {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }
    }
    public partial class StudentInformationClass
    {
        public static long SetStudentNo = 0;
        public static long SetContactNo = 0;
        public static int SetAge = 0;
        public static string SetProgram = "";
        public static string SetGender = "";
        public static string SetBirthday = "";
        public static string SetFullName = "";
    }
}
