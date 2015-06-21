using System;
using System.Threading;

namespace DummyIMAPSendEmail
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String smtp_host = "smtp.gmail.com";
			String email = "from@gmail.com";
			String password = "PASSWORD";
			bool isSSL = true;
			String msg_body = "Test Test";
			String sender_address = "from@gmail.com";
			String reciever_address = "to@gmail.com";
			String subject = "Subject1";

			SendMsg_BaronTry send_msg = new SendMsg_BaronTry ();

			// Sending a message
			send_msg.send (smtp_host, email, password, isSSL,
				msg_body, sender_address, reciever_address, subject);

//			}
		}
	}
}
