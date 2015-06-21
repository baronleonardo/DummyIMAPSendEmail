using System;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;

namespace DummyIMAPSendEmail
{
	public class SendMsg_BaronTry
	{
		public MailMessage send( String smtp_host, String login, String password,
			bool isSSL, String msg_body, String sender_address, String reciever_address, String subject )
		{
			MailMessage msg = null;

			try
			{
				// Create the message first
				msg = create_email_msg(msg_body, sender_address, reciever_address, subject);
				// Create a smtp client
				var client = create_client( smtp_host, login, password, isSSL );

				// Send the msg
				client.Send (msg);
				client.Dispose ();
//				client.Send (msg);
//				client.SendAsync(msg, subject);
//
//				string answer = Console.ReadLine();
//
//				if (answer.StartsWith("c") && mailSent == false)
//				{
//					client.SendAsyncCancel();
//				}
			}

			catch(Exception e)
			{
//				throw new Exception("Mail.Send: " + e.Message);
				return null;
			}

			return msg;
		}

		MailMessage create_email_msg(String msg_body, String sender_address, String reciever_address, String subject)
		{

			// Add the address of the sender
			MailAddress from = new MailAddress (sender_address);
			// Add the address of the reciever
			MailAddress to = new MailAddress (reciever_address);

			// Create email data
			MailMessage message = new MailMessage (from, to);

			// Add the message body of the email
			message.Body = msg_body + " ";
			string someArrows = new string(new char[] {'\u2190', '\u2191', '\u2192', '\u2193'});
			message.Body += Environment.NewLine + someArrows;
			message.BodyEncoding =  System.Text.Encoding.UTF8;

			// Add Subject to the email
			message.Subject = subject + someArrows;
			message.SubjectEncoding = System.Text.Encoding.UTF8;

			return message;
		}

		SmtpClient create_client(String smtp_host, String login, String password, bool isSSL)
		{
			// Create smtp client
			var client = new SmtpClient();

			// Add the smtp host
			client.Host = smtp_host;

			Console.WriteLine (client.Port);

			// smtp port
//			if (isSSL)
//				client.Port = 465;
//			else
			// 587
				client.Port = 587;

			client.UseDefaultCredentials = false;

			// Add Secure Socket Layer
			client.EnableSsl = true;

			client.Timeout = 20000;

			// Credientials
			var credentials = new NetworkCredential( login, password );
			client.Credentials = credentials;

			client.DeliveryMethod = SmtpDeliveryMethod.Network;

			return client;
		}
	}
}

