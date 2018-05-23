

namespace ListasDemo.Model
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
	using ListasDemo.ViewModel;
	using SQLite;

	public class Friend:Notificable
    {
		[PrimaryKey,AutoIncrement]
		public int ID { get; set; }
		private string firstName;
		private string phone;
		private string email;


		public string FirstName
        {
            get
            {
				return firstName;
            }
            set
            {
				SetValue(ref firstName, value);
            }

        }
		public string Phone
        {
            get
            {
				return phone;
            }
            set
            {
				SetValue(ref phone, value);
            }

        }
		public string Email
        {
            get
            {
				return email;
            }
            set
            {
				SetValue(ref email, value);
            }

        }
    }
}
