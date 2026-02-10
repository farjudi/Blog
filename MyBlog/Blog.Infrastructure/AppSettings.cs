using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure;

public class AppSettings
{
    public ModulesSettings Modules { get; set; }
}

public class ModulesSettings
{
    public SmsSettings Sms { get; set; }
}
public class SmsSettings
{
    public KavehNegarSettings KavehNegar { get; set; }

}

public class KavehNegarSettings
{
    public string ApiKey { get; set; }
    public string SenderNumber { get; set; }
}
