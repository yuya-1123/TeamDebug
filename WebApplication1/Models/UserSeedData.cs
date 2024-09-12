using TeamD_Database;
using TeamD_Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using WebApplication1.Models;


namespace WebApplication1.Models
{
    public class UserSeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(
                serviceProvider.GetRequiredService<DbContextOptions<WebApplication1Context>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return; // DB has been seeded
                }

                /*var devices = context.Device;

                foreach (Device d in devices)
                {
                    context.Rental.AddRange(
                        new Rental 
                        { 
                            AssetsNo = d.AssetsNo,
                            Vacant = false,
                        }
                        );
                }
                context.SaveChanges();*/
                //ユーザのシードデータ
                context.User.AddRange(
                    new User
                    {
                        EmployeeNo = "A1002",
                        Name = "森脇克美",
                        Namekana = "モリワキカツミ",
                        MailAdress = "katsumi124@clpxtxlcu.ff",
                        TelNo = "235868783",
                        Age = 49,
                        RegisterDate = DateTime.Now,
                        Gender = 1,
                        DeleteFlag = false,
                        Position = "一般",
                        department = "開発1課",
                        AccountLevel = "管理者",
                    },

                    new User
                    {
                        EmployeeNo = "B1003",
                        Name = "真鍋沙奈",
                        Namekana = "マナベサナ",
                        department = "開発2課",
                        TelNo = "26464038",
                        MailAdress = "amanabe@lkfolssvfl.hczpp.pc",
                        Age = 55,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },
                    
                    new User
                    {
                        EmployeeNo = "B1004",
                        Name = "高梨愛姫",
                        Namekana = "タカナシアキ",
                        department = "開発2課",
                        TelNo = "733344935",
                        MailAdress = "Aki_Takanashi@ajtkcn.yk",
                        Age = 25,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    }, 
                    
                    new User
                    {
                        EmployeeNo = "B1005",
                        Name = "浅川彩香",
                        Namekana = "アサカワアヤカ",
                        department = "開発2課",
                        TelNo = "765654624",
                        MailAdress = "ayaka53863@hnrwwzt.ouk",
                        Age = 46,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "B1006",
                        Name = "山城凛香",
                        Namekana = "ヤマシロリンカ",
                        department = "開発2課",
                        TelNo = "491295233",
                        MailAdress = "rinkayamashiro@iriqg.bkxcb.ttc",
                        Age = 22,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1010",
                        Name = "生田瑞紀",
                        Namekana = "イクタミズキ",
                        department = "開発1課",
                        TelNo = "85223705",
                        MailAdress = "mizuki_ikuta@dkjnjxka.lran.sk",
                        Age = 55,
                        Gender = 1,
                        Position = "部長",
                        AccountLevel = "管理者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1011",
                        Name = "小峰嶺渡",
                        Namekana = "コミネミネト",
                        department = "開発1課",
                        TelNo = "237533606",
                        MailAdress = "gl-fgujhlzunawvmineto16563@qdywk.nwned.fk",
                        Age = 26,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1012",
                        Name = "紺野信一",
                        Namekana = "コンノシンイチ",
                        department = "開発1課",
                        TelNo = "417985133",
                        MailAdress = "shinichi117@htnsvbdwmx.df.hi",
                        Age = 50,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1013",
                        Name = "波多野正義",
                        Namekana = "ハタノマサヨシ",
                        department = "開発1課",
                        TelNo = "473935195",
                        MailAdress = "Masayoshi_Hatano@mwxuaibo.nxxo.cc",
                        Age = 53,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1014",
                        Name = "山口桜子",
                        Namekana = "ヤマグチサクラコ",
                        department = "開発1課",
                        TelNo = "859380890",
                        MailAdress = "oyamaguchi@hfyc.jvj",
                        Age = 36,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1015",
                        Name = "伴景子",
                        Namekana = "バンケイコ",
                        department = "開発1課",
                        TelNo = "896187706",
                        MailAdress = "Keiko_Ban@ydtq.vi.qot",
                        Age = 40,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1016",
                        Name = "渡部昌利",
                        Namekana = "ワタナベマサトシ",
                        department = "開発1課",
                        TelNo = "738969256",
                        MailAdress = "iwatanabe@uvwzzyek.nin",
                        Age = 25,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1017",
                        Name = "川西宏光",
                        Namekana = "カワニシヒロミツ",
                        department = "開発1課",
                        TelNo = "446709239",
                        MailAdress = "Hiromitsu_Kawanishi@qyjcm.ngfg.re",
                        Age = 32,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1018",
                        Name = "大貫実可",
                        Namekana = "オオヌキミカ",
                        department = "開発1課",
                        TelNo = "895298503",
                        MailAdress = "mika8222@clkwr.ye",
                        Age = 50,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1019",
                        Name = "小玉加奈",
                        Namekana = "コダマカナ",
                        department = "開発1課",
                        TelNo = "989294146",
                        MailAdress = "kana6330@uaxzxngc.co.csz",
                        Age = 47,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1020",
                        Name = "三村菜月",
                        Namekana = "ミムラナヅキ",
                        department = "開発1課",
                        TelNo = "768931048",
                        MailAdress = "nazuki_mimura@rmxuls.ruyb.oqg",
                        Age = 42,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1021",
                        Name = "細谷松太郎",
                        Namekana = "ホソヤマツタロウ",
                        department = "開発1課",
                        TelNo = "294689528",
                        MailAdress = "matsutarou_hosoya@osyjbr.ut.btz",
                        Age = 37,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1022",
                        Name = "岩瀬亜沙美",
                        Namekana = "イワセアサミ",
                        department = "開発1課",
                        TelNo = "890241950",
                        MailAdress = "asami41809@fyqjhh.eih.xjy",
                        Age = 34,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1023",
                        Name = "中本道夫",
                        Namekana = "ナカモトミチオ",
                        department = "開発1課",
                        TelNo = "854809728",
                        MailAdress = "michio139@uaozem.hl",
                        Age = 45,
                        Gender = 0,
                        Position = "課長",
                        AccountLevel = "管理者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1024",
                        Name = "深沢伊代",
                        Namekana = "フカザワイヨ",
                        department = "開発1課",
                        TelNo = "748803221",
                        MailAdress = "Iyo_Fukazawa@wqaufggth.yljjd.kc",
                        Age = 42,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1025",
                        Name = "内田康博",
                        Namekana = "ウチダヤスヒロ",
                        department = "開発1課",
                        TelNo = "733077872",
                        MailAdress = "yasuhiro321@posblq.vmw",
                        Age = 28,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "A1026",
                        Name = "成田宗平",
                        Namekana = "ナリタソウヘイ",
                        department = "開発1課",
                        TelNo = "537290977",
                        MailAdress = "souhei7840@yfnwbqiyd.lnv",
                        Age = 20,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "C2001",
                        Name = "中原孝",
                        Namekana = "ナカハラタカシ",
                        department = "営業1課",
                        TelNo = "239266713",
                        MailAdress = "n-iaqggmvvtakashi8324@yhdplomkvf.vd",
                        Age = 22,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "C2002",
                        Name = "赤木真幸",
                        Namekana = "アカギマサキ",
                        department = "営業1課",
                        TelNo = "175488902",
                        MailAdress = "masaki48828@wukygyyrit.ua",
                        Age = 42,
                        Gender = 0,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "C2003",
                        Name = "武井米子",
                        Namekana = "タケイヨネコ",
                        department = "営業1課",
                        TelNo = "799064779",
                        MailAdress = "aupmgrmrcjfnbyoneko62050@glcbxipdvn.ml.tgc",
                        Age = 23,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new User
                    {
                        EmployeeNo = "C2004",
                        Name = "高井日菜乃",
                        Namekana = "タカイヒナノ",
                        department = "営業1課",
                        TelNo = "833220779",
                        MailAdress = "fplhcpnfhvu=whinano603@cthbnv.lnt",
                        Age = 57,
                        Gender = 1,
                        Position = "一般",
                        AccountLevel = "利用者",
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                     new User
                     {
                         EmployeeNo = "C2005",
                         Name = "堤明日人",
                         Namekana = "ツツミアスト",
                         department = "営業1課",
                         TelNo = "583972707",
                         MailAdress = "asuto913@pilddsgte.dhy",
                         Age = 20,
                         Gender = 0,
                         Position = "一般",
                         AccountLevel = "利用者",
                         RegisterDate = DateTime.Now,
                         DeleteFlag = false,
                     },

                     new User
                     {
                         EmployeeNo = "B1201",
                         Name = "岡崎桃歌",
                         Namekana = "オカザキモモカ",
                         department = "開発2課",
                         TelNo = "229681855",
                         MailAdress = "aokazaki@hcexkvbds.dwu",
                         Age = 36,
                         Gender = 1,
                         Position = "一般",
                         AccountLevel = "利用者",
                         RegisterDate = DateTime.Now,
                         DeleteFlag = false,
                     },

                     new User
                     {
                         EmployeeNo = "B1202",
                         Name = "児玉忠正",
                         Namekana = "コダマタダマサ",
                         department = "開発2課",
                         TelNo = "985930354",
                         MailAdress = "tadamasa31219@kroscxis.an",
                         Age = 26,
                         Gender = 0,
                         Position = "一般",
                         AccountLevel = "利用者",
                         RegisterDate = DateTime.Now,
                         DeleteFlag = false,
                     },

                     new User
                     {
                         EmployeeNo = "B1203",
                         Name = "塚田巧聖",
                         Namekana = "ツカダコウセイ",
                         department = "開発2課",
                         TelNo = "23515302",
                         MailAdress = "kouseitsukada@ubhmkvc.qy",
                         Age = 27,
                         Gender = 0,
                         Position = "一般",
                         AccountLevel = "利用者",
                         RegisterDate = DateTime.Now,
                         DeleteFlag = false,
                     },

                     new User
                     {
                         EmployeeNo = "A1301",
                         Name = "熊沢正人",
                         Namekana = "クマザワマサト",
                         department = "開発1課",
                         TelNo = "749046045",
                         MailAdress = "masato94066@hbcjhfwegj.ryj",
                         Age = 28,
                         Gender = 0,
                         Position = "一般",
                         AccountLevel = "利用者",
                         RegisterDate = DateTime.Now,
                         DeleteFlag = false,
                     },

                     new User
                     {
                         EmployeeNo = "A1302",
                         Name = "柳敦司",
                         Namekana = "ヤナギアツシ",
                         department = "開発1課",
                         TelNo = "467953943",
                         MailAdress = "ybjcbvojsjjybatsushi58903@hxiu.glk",
                         Age = 48,
                         Gender = 0,
                         Position = "一般",
                         AccountLevel = "利用者",
                         RegisterDate = DateTime.Now,
                         DeleteFlag = false,
                     },

                     new User
                     {
                         EmployeeNo = "Z0101",
                         Name = "黒田秀加",
                         Namekana = "クロダヒデカ",
                         department = "情報システム部",
                         TelNo = "157061581",
                         MailAdress = "hideka82106@ovwtkeph.uze",
                         Age = 57,
                         Gender = 1,
                         Position = "一般",
                         AccountLevel = "利用者",
                         RegisterDate = DateTime.Now,
                         DeleteFlag = false,
                     },

                     new User
                     {
                         EmployeeNo = "Z0102",
                         Name = "佐竹紫雲",
                         Namekana = "サタケシウン",
                         department = "情報システム部",
                         TelNo = "264267595",
                         MailAdress = "shiun814@qamcpg.ovomz.tfp",
                         Age = 27,
                         Gender = 0,
                         Position = "一般",
                         AccountLevel = "利用者",
                         RegisterDate = DateTime.Now,
                         DeleteFlag = false,
                     }
                     );

                //機器のシードデータ------------------------------------------------------------------
                context.Device.AddRange(
                    new Device 
                    { 
                        AssetsNo = "A19-06-001",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-001",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-002",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-002",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-003",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-003",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-004",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-004",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-005",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-005",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-006",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-006",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-007",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-007",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-008",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-008",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-009",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-009",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-010",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-010",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-011",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-011",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-012",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-012",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-013",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-013",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-014",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-014",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-015",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-015",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-016",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-016",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-017",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-017",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A19-06-018",
                        Maker = "Dell",
                        Os = "Windows10",
                        Memory = "8GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-018",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A20-01-001",
                        Maker = "HP",
                        Os = "Windows10",
                        Memory = "16GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-019",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A20-01-002",
                        Maker = "HP",
                        Os = "Windows10",
                        Memory = "16GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-020",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A20-01-003",
                        Maker = "HP",
                        Os = "Windows10",
                        Memory = "16GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-021",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A20-01-004",
                        Maker = "HP",
                        Os = "Windows10",
                        Memory = "16GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-022",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A20-01-005",
                        Maker = "HP",
                        Os = "Windows10",
                        Memory = "16GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-023",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A20-01-006",
                        Maker = "HP",
                        Os = "Windows10",
                        Memory = "16GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-024",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "A20-01-007",
                        Maker = "HP",
                        Os = "Windows10",
                        Memory = "16GB",
                        Capacity = "500GB",
                        Graphics = false,
                        Location = "classroom-025",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "B20-01-001",
                        Maker = "Mouse",
                        Os = "Windows10",
                        Memory = "32GB",
                        Capacity = "1TB",
                        Graphics = false,
                        Location = "classroom-026",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "B20-01-002",
                        Maker = "Mouse",
                        Os = "Windows10",
                        Memory = "32GB",
                        Capacity = "1TB",
                        Graphics = false,
                        Location = "classroom-027",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    },

                    new Device
                    {
                        AssetsNo = "B20-01-003",
                        Maker = "Mouse",
                        Os = "Windows10",
                        Memory = "32GB",
                        Capacity = "1TB",
                        Graphics = false,
                        Location = "classroom-028",
                        Break = false,
                        RegisterDate = DateTime.Now,
                        DeleteFlag = false,
                    }
                    );

                context.Rental.AddRange(
                    new Rental
                    {
                        AssetsNo = "A19-06-001",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-002",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-003",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-004",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-005",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-006",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-007",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-008",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-009",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-010",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-011",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-012",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-013",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-014",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-015",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-016",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-017",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A19-06-018",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A20-01-001",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A20-01-002",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A20-01-003",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A20-01-004",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A20-01-005",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A20-01-006",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "A20-01-007",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "B20-01-001",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "B20-01-002",
                        Vacant = false,
                    },

                    new Rental
                    {
                        AssetsNo = "B20-01-003",
                        Vacant = false,
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

