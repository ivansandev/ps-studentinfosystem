using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseIt
{
    public class Person
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public List<Expense> Expenses;
    }
}
