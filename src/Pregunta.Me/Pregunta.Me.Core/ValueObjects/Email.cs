﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta.Me.Core.ValueObjects
{
    public class Email
    {
        private readonly MailAddress _mailAddress;

        public static Email Create(string email, string displayName)
        {
            var e = new Email(email, displayName);
            return e;
        }

        private Email(string email, string displayName)
        {
            _mailAddress = MakeEmailAddress(email, displayName);
        }

        public string Address { get { return _mailAddress.Address; } }
        public string DisplayName { get { return _mailAddress.DisplayName; } }
        public string Host { get { return _mailAddress.Host; } }
        public string User { get { return _mailAddress.User; } }

        private MailAddress MakeEmailAddress(string email, string displayName)
        {
            if (string.IsNullOrEmpty(email)) { throw new ArgumentNullException("Email cannot be null or empty."); }
            if (string.IsNullOrEmpty(displayName)) { throw new ArgumentNullException("Display Name cannot be null or empty."); }
            var anEmailAddress = new MailAddress(email, displayName, Encoding.Unicode);
            return anEmailAddress;
        }
    }
}
