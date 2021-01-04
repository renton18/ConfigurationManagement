using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ConfigurationManagement.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CONFIG_DBContext(serviceProvider.GetRequiredService<DbContextOptions<CONFIG_DBContext>>()))
            {
                //if (context.MConfigurationManagements.Any())
                //{
                //    return;   // DB has been seeded
                //}

                context.MConfigurationManagements.AddRange(
                new MConfigurationManagement { Host = "H", HostDetail = "H_PC", HostType = 0, Place = "自宅", UserName = "H", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "S", HostDetail = "S_PC", HostType = 0, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "3DS", HostDetail = "3DS", HostType = 4, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "H携帯", HostDetail = "Arrows携帯 M02", HostType = 2, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "ASUS", HostDetail = "ASUS ZenPad P00A", HostType = 2, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "HDレコーダ", HostDetail = "HDレコーダー", HostType = 4, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "LAVIE EXSi", HostDetail = "LAVIE EXSi", HostType = 1, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "CentOS7", HostDetail = "CentOS7", HostType = 1, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "テスト1", HostDetail = "テスト1", HostType = 0, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "テスト2", HostDetail = "テスト2", HostType = 0, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "テスト3", HostDetail = "テスト3", HostType = 0, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "テスト4", HostDetail = "テスト4", HostType = 0, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MConfigurationManagement { Host = "テスト5", HostDetail = "テスト5", HostType = 0, Place = "自宅", UserName = "S", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() });

                context.MAccounts.AddRange(
                new MAccount { ConfigurationManagementSeq = 0, AccountType = 0, DatabaseName = "", Id = "user01", Pass = "user01", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MAccount { ConfigurationManagementSeq = 0, AccountType = 1, DatabaseName = "CONFIG_DB", Id = "sa", Pass = "sa", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MAccount { ConfigurationManagementSeq = 1, AccountType = 0, DatabaseName = "", Id = "user02", Pass = "user02", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() }
                );

                context.MNetworks.AddRange(
                new MNetwork { ConfigurationManagementSeq = 1, IpAddress = "192.168.0.20", SubnetMask = "255.255.255.0", DefaultGetway = "192.168.0.1", Dns1 = "192.168.0.1", Dns2 = "192.168.0.1", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() },
                new MNetwork { ConfigurationManagementSeq = 2, IpAddress = "192.168.0.21", SubnetMask = "255.255.255.0", DefaultGetway = "192.168.0.1", Dns1 = "192.168.0.1", Dns2 = "192.168.0.1", CreateDt = DateTime.Now, CreateId = "System", CreateTer = Dns.GetHostName() }
                );

                context.SaveChanges();
            }
        }
    }
}
