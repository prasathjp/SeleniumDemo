namespace StudentDemo
{
    public class Student
    {
        //Private Data Members
        private int _studentRollno;
        private string _studentName;
        private string _studentMailId;
        private float _studentPercentage;
        public static string SchoolName = "Global School";
        public static string SchoolAddress = "Chennai";

        //StudentRollNo property
        public int StudentRollNo
        {
            get
            {
                return _studentRollno;
            }
            set
            {
                _studentRollno = value;
            }
        }

        //StudentName property
        public string StudentName
        {
            get
            {
                return _studentName;
            }
            set
            {
                _studentName = value;
            }
        }

        //StudentMailId property
        public string StudentMailId
        {
            get
            {
                return _studentMailId;
            }
            set
            {
                _studentMailId = value;
            }
        }

        //StudentPercentage property
        public float StudentPercentage
        {
            get
            {
                return _studentPercentage;
            }
            set
            {
                _studentPercentage = value;
            }
        }
        
        //Parameterized Constructor
        public Student(int studentRollno, string studentName, string studentMailId, float studentPercentage)
        {
            StudentRollNo = studentRollno;
            StudentName = studentName;
            StudentMailId = studentMailId;
            StudentPercentage = studentPercentage;
        }
    }
}