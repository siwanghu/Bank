using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinUI
{
    class ConfigureXml
    {
        private string xmlpath = "configure.xml";
        private static ConfigureXml configrueXml = null;
        private XDocument document = null;
        private ConfigureXml()
        {
            document = XDocument.Load("configure.xml");
        }

        public static ConfigureXml getInstance()
        {
            if (configrueXml == null)
            {
                configrueXml = new ConfigureXml();
                return configrueXml;
            }
            else
            {
                return configrueXml;
            }
        }

        public void setUIForm(string id)
        {
            XElement root = document.Root;
            XElement uiConfigure = root.Element("uiConfigure");
            XElement ui = uiConfigure.Element("ui");
            ui.SetValue(id);
            root.Save(xmlpath);
        }

        public string getUIForm()
        {
            XElement root = document.Root;
            XElement uiConfigure = root.Element("uiConfigure");
            XElement ui = uiConfigure.Element("ui");
            return ui.Value;
        }

        public void setUIForm_Control_Background(string path)
        {
            XElement root = document.Root;
            XElement uiConfigure = root.Element("uiConfigure");
            XElement control_background = uiConfigure.Element("control_background");
            control_background.SetValue(path);
            root.Save(xmlpath);
        }

        public string getUIForm_Control_Background()
        {
            XElement root = document.Root;
            XElement uiConfigure = root.Element("uiConfigure");
            XElement control_background = uiConfigure.Element("control_background");
            return control_background.Value;
        }

        public void setUIForm_Background(string path)
        {
            XElement root = document.Root;
            XElement uiConfigure = root.Element("uiConfigure");
            XElement background = uiConfigure.Element("background");
            background.SetValue(path);
            root.Save(xmlpath);
        }

        public string getUIForm_Background()
        {
            XElement root = document.Root;
            XElement uiConfigure = root.Element("uiConfigure");
            XElement background = uiConfigure.Element("background");
            return background.Value;
        }

        public void setUIForm_id_name(string[] id_name)
        {
            int length = id_name.Length;
            switch (length)
            {
                case 3:
                    XElement root = document.Root;
                    XElement uiConfigure = root.Element("uiConfigure");
                    XElement id_name_one = uiConfigure.Element("id_name_one");
                    XElement id_name_two = uiConfigure.Element("id_name_two");
                    XElement id_name_three = uiConfigure.Element("id_name_three");
                    id_name_one.SetValue(id_name[0]);
                    id_name_two.SetValue(id_name[1]);
                    id_name_three.SetValue(id_name[2]);
                    root.Save(xmlpath);
                    break;
                case 4:
                    XElement _root = document.Root;
                    XElement _uiConfigure = _root.Element("uiConfigure");
                    XElement _id_name_one = _uiConfigure.Element("id_name_one");
                    XElement _id_name_two = _uiConfigure.Element("id_name_two");
                    XElement _id_name_three = _uiConfigure.Element("id_name_three");
                    XElement _id_name_four = _uiConfigure.Element("id_name_four");
                    _id_name_one.SetValue(id_name[0]);
                    _id_name_two.SetValue(id_name[1]);
                    _id_name_three.SetValue(id_name[2]);
                    _id_name_four.SetValue(id_name[3]);
                    _root.Save(xmlpath);
                    break;
                case 6:
                    XElement _root_ = document.Root;
                    XElement _uiConfigure_ = _root_.Element("uiConfigure");
                    XElement _id_name_one_ = _uiConfigure_.Element("id_name_one");
                    XElement _id_name_two_ = _uiConfigure_.Element("id_name_two");
                    XElement _id_name_three_ = _uiConfigure_.Element("id_name_three");
                    XElement _id_name_four_ = _uiConfigure_.Element("id_name_four");
                    XElement _id_name_five_ = _uiConfigure_.Element("id_name_five");
                    XElement _id_name_six_ = _uiConfigure_.Element("id_name_six");
                    _id_name_one_.SetValue(id_name[0]);
                    _id_name_two_.SetValue(id_name[1]);
                    _id_name_three_.SetValue(id_name[2]);
                    _id_name_four_.SetValue(id_name[3]);
                    _id_name_five_.SetValue(id_name[4]);
                    _id_name_six_.SetValue(id_name[5]);
                    _root_.Save(xmlpath);
                    break;
                default:
                    return;
            }
        }

        public string[] getUIForm_id_name()
        {
            int length = int.Parse(this.getUIForm());
            switch (length)
            {
                case 1:
                    XElement root = document.Root;
                    XElement uiConfigure = root.Element("uiConfigure");
                    XElement id_name_one = uiConfigure.Element("id_name_one");
                    XElement id_name_two = uiConfigure.Element("id_name_two");
                    XElement id_name_three = uiConfigure.Element("id_name_three");
                    string name_one = id_name_one.Value;
                    string name_two = id_name_two.Value;
                    string name_three = id_name_three.Value;
                    return new string[] { name_one, name_two, name_three };
                case 2:
                    XElement _root = document.Root;
                    XElement _uiConfigure = _root.Element("uiConfigure");
                    XElement _id_name_one = _uiConfigure.Element("id_name_one");
                    XElement _id_name_two = _uiConfigure.Element("id_name_two");
                    XElement _id_name_three = _uiConfigure.Element("id_name_three");
                    XElement _id_name_four = _uiConfigure.Element("id_name_four");
                    string _name_one = _id_name_one.Value;
                    string _name_two = _id_name_two.Value;
                    string _name_three = _id_name_three.Value;
                    string _name_four = _id_name_four.Value;
                    return new string[] { _name_one, _name_two, _name_three, _name_four };
                case 3:
                    XElement _root_ = document.Root;
                    XElement _uiConfigure_ = _root_.Element("uiConfigure");
                    XElement _id_name_one_ = _uiConfigure_.Element("id_name_one");
                    XElement _id_name_two_ = _uiConfigure_.Element("id_name_two");
                    XElement _id_name_three_ = _uiConfigure_.Element("id_name_three");
                    XElement _id_name_four_ = _uiConfigure_.Element("id_name_four");
                    XElement _id_name_five_ = _uiConfigure_.Element("id_name_five");
                    XElement _id_name_six_ = _uiConfigure_.Element("id_name_six");
                    string _name_one_ = _id_name_one_.Value;
                    string _name_two_ = _id_name_two_.Value;
                    string _name_three_ = _id_name_three_.Value;
                    string _name_four_ = _id_name_four_.Value;
                    string _name_five_ = _id_name_five_.Value;
                    string _name_six_ = _id_name_six_.Value;
                    return new string[] { _name_one_, _name_two_, _name_three_, _name_four_, _name_five_, _name_six_ };
                default:
                    return null;
            }
        }

        public void setScreenForm_title(string head)
        {
            XElement root = document.Root;
            XElement screenConfigure = root.Element("screenConfigure");
            XElement title = screenConfigure.Element("title");
            title.SetValue(head);
            root.Save(xmlpath);
        }

        public string getScreenForm_title()
        {
            XElement root = document.Root;
            XElement screenConfigure = root.Element("screenConfigure");
            XElement title = screenConfigure.Element("title");
            return title.Value;
        }

        public void setScreenForm_Background(string path)
        {
            XElement root = document.Root;
            XElement screenConfigure = root.Element("screenConfigure");
            XElement background = screenConfigure.Element("background");
            background.SetValue(path);
            root.Save(xmlpath);
        }

        public string getScreenForm_Background()
        {
            XElement root = document.Root;
            XElement screenConfigure = root.Element("screenConfigure");
            XElement background = screenConfigure.Element("background");
            return background.Value;
        }

        public void setVIPForm_numbers(string[] vips)
        {
            int length = vips.Length;
            switch (length)
            {
                case 1:
                    XElement root = document.Root;
                    XElement vipConfigure = root.Element("vipConfigure");
                    XElement vip_number = vipConfigure.Element("vip_number");
                    XElement vip_number_one = vipConfigure.Element("vip_number_one");
                    vip_number.SetValue(Convert.ToString(length));
                    vip_number_one.SetValue(Convert.ToString(vips[0]));
                    root.Save(xmlpath);
                    break;
                case 2:
                    XElement _root = document.Root;
                    XElement _vipConfigure = _root.Element("vipConfigure");
                    XElement _vip_number = _vipConfigure.Element("vip_number");
                    XElement _vip_number_one = _vipConfigure.Element("vip_number_one");
                    XElement _vip_number_two = _vipConfigure.Element("vip_number_two");
                    _vip_number.SetValue(Convert.ToString(length));
                    _vip_number_one.SetValue(Convert.ToString(vips[0]));
                    _vip_number_two.SetValue(Convert.ToString(vips[1]));
                    _root.Save(xmlpath);
                    break;
                case 3:
                    XElement _root_ = document.Root;
                    XElement _vipConfigure_ = _root_.Element("vipConfigure");
                    XElement _vip_number_ = _vipConfigure_.Element("vip_number");
                    XElement _vip_number_one_ = _vipConfigure_.Element("vip_number_one");
                    XElement _vip_number_two_ = _vipConfigure_.Element("vip_number_two");
                    XElement _vip_number_three_ = _vipConfigure_.Element("vip_number_three");
                    _vip_number_.SetValue(Convert.ToString(length));
                    _vip_number_one_.SetValue(Convert.ToString(vips[0]));
                    _vip_number_two_.SetValue(Convert.ToString(vips[1]));
                    _vip_number_three_.SetValue(Convert.ToString(vips[2]));
                    _root_.Save(xmlpath);
                    break;
                default:
                    return;
            }
        }

        public string[] getVIForm_numbers()
        {
            XElement root = document.Root;
            XElement vipConfigure = root.Element("vipConfigure");
            XElement vip_number = vipConfigure.Element("vip_number");
            int number = int.Parse(vip_number.Value);
            switch (number)
            {
                case 1:
                    XElement vip_number_one = vipConfigure.Element("vip_number_one");
                    return new string[] { vip_number_one.Value };
                case 2:
                    XElement _vip_number_one = vipConfigure.Element("vip_number_one");
                    XElement _vip_number_two = vipConfigure.Element("vip_number_two");
                    return new string[] { _vip_number_one.Value, _vip_number_two.Value };
                case 3:
                    XElement _vip_number_one_ = vipConfigure.Element("vip_number_one");
                    XElement _vip_number_two_ = vipConfigure.Element("vip_number_two");
                    XElement _vip_number_three_ = vipConfigure.Element("vip_number_three");
                    return new string[] { _vip_number_one_.Value, _vip_number_two_.Value, _vip_number_three_.Value };
                default:
                    return null;
            }
        }

        public void setPrintForm_titles(bool[] bools)
        {
            XElement root = document.Root;
            XElement printConfigure = root.Element("printConfigure");
            XElement title_welcome = printConfigure.Element("title_welcome");
            XElement title_number = printConfigure.Element("title_number");
            XElement title_queue = printConfigure.Element("title_queue");
            XElement title_time = printConfigure.Element("title_time");
            if (4 == bools.Length)
            {
                string welcome = bools[0] ? "true" : "false";
                string number = bools[1] ? "true" : "false";
                string queue = bools[2] ? "true" : "false";
                string time = bools[3] ? "true" : "false";
                title_welcome.SetValue(welcome);
                title_number.SetValue(number);
                title_queue.SetValue(queue);
                title_time.SetValue(time);
                root.Save(xmlpath);
            }
        }

        public bool[] getPrintForm_titles()
        {
            XElement root = document.Root;
            XElement printConfigure = root.Element("printConfigure");
            XElement title_welcome = printConfigure.Element("title_welcome");
            XElement title_number = printConfigure.Element("title_number");
            XElement title_queue = printConfigure.Element("title_queue");
            XElement title_time = printConfigure.Element("title_time");
            bool welcome = title_welcome.Value.Equals("true") ? true : false;
            bool number = title_number.Value.Equals("true") ? true : false;
            bool queue = title_queue.Value.Equals("true") ? true : false;
            bool time = title_time.Value.Equals("true") ? true : false;
            return new bool[] { welcome, number, queue, time };
        }

        public void setLanguageForm_languages(bool[] languages)
        {
            XElement root = document.Root;
            XElement languageConfigure = root.Element("languageConfigure");
            XElement chineseEle = languageConfigure.Element("chinese");
            XElement englishEle = languageConfigure.Element("english");
            if (2 == languages.Length)
            {
                string chinese = languages[0] ? "true" : "false";
                string english = languages[1] ? "true" : "false";
                chineseEle.SetValue(chinese);
                englishEle.SetValue(english);
                root.Save(xmlpath);
            }
        }

        public bool[] getLanguageForm_languages()
        {
            XElement root = document.Root;
            XElement languageConfigure = root.Element("languageConfigure");
            XElement chineseEle = languageConfigure.Element("chinese");
            XElement englishEle = languageConfigure.Element("english");
            bool chinese = chineseEle.Value.Equals("true") ? true : false;
            bool english = englishEle.Value.Equals("true") ? true : false;
            return new bool[] { chinese, english };
        }

        public void setPasswordForm_password(string password_encryption)
        {
            XElement root = document.Root;
            XElement passwordConfigure = root.Element("passwordConfigure");
            XElement password = passwordConfigure.Element("password");
            password.SetValue(password_encryption);
            root.Save(xmlpath);
        }

        public string getPassword_password()
        {
            XElement root = document.Root;
            XElement passwordConfigure = root.Element("passwordConfigure");
            XElement password = passwordConfigure.Element("password");
            return password.Value;
        }
    }
}
