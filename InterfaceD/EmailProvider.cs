﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceD
{
    public interface EmailProvider
    {
        public IEnumerable<EmailInfo> SendEmail();

        public IEnumerable<EmailInfo> Send2Email();
    }
}
