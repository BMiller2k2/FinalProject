using SQLite;

namespace FinalProject.SQLite
{
    public class Tables
	{
        public class DBVersion
        {
            [PrimaryKey]
            [AutoIncrement]
            public int SNo { get; set; }
            public int DBVersionNumber { get; set; }
        }

        public class ToDoItem
        {
            [PrimaryKey,]
            [AutoIncrement]
            public int ID { get; set; }
            public string ItemName { get; set; }
            public bool IsDone { get; set; }
        }

    }
}

