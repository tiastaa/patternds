using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text.Json;

namespace Lab1
{
    class Factory
    {
        class OnlineMeeting
        {
            public string date;
            public string description;
            private string url;
            public User[] users;

            public OnlineMeeting(string date, string description, string url, User[] users)
            {
                this.date = date;
                this.description = description;
                this.url = url;
                this.users = users;
            }

            public void  MakeXmlFile()
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("C:\\Users\\NIKA\\source\\repos\\ConsoleApp1\\ConsoleApp1\\XMLFile1.xml");
                XmlElement? xRoot = xDoc.DocumentElement;

                XmlElement meetingElem = xDoc.CreateElement("meeting");


                XmlAttribute urlAttr = xDoc.CreateAttribute("url");


                XmlElement dateElem = xDoc.CreateElement("date");
                XmlElement descriptionElem = xDoc.CreateElement("description");
                XmlElement userdsElem = xDoc.CreateElement("users");

                XmlText urlText = xDoc.CreateTextNode(this.url);
                XmlText dateText = xDoc.CreateTextNode(this.date);
                XmlText descriptionText = xDoc.CreateTextNode(this.description);


                urlAttr.AppendChild(urlText);
                dateElem.AppendChild(dateText);
                descriptionElem.AppendChild(descriptionText);

                meetingElem.Attributes.Append(urlAttr);

                meetingElem.AppendChild(dateElem);
                meetingElem.AppendChild(descriptionElem);

                xRoot?.AppendChild(meetingElem);

                xDoc.Save("C:\\Users\\NIKA\\source\\repos\\ConsoleApp1\\ConsoleApp1\\XMLFile1.xml");
            }
            public void MakeJsonFile()
            {

                string jsonDescription = JsonSerializer.Serialize(this.description)  ;
                string jsonUrl = JsonSerializer.Serialize( this.url);
                string jsonDate = JsonSerializer.Serialize( this.date);
                Console.WriteLine(  jsonUrl ) ;
                Console.WriteLine(jsonDescription);
                Console.WriteLine( jsonDate);

            }
        }
        


        

        class User
        {
            public string id;
            public string name;
            public string img;

            public User(string id, string name, string img)
            {
                this.id = id;
                this.name = name;
                this.img = img;
            }



            public override string ToString()
            {
                return $"{this.id}";
            }
        }


        static void Main(string[] args)
        {
            User u1 = new User("1", "Nika", "https://kartinkin.net/uploads/posts/2022-03/1647908437_1-kartinkin-net-p-klassnie-kartinki-dlya-devochek-1.jpg");
            User u2 = new User("2", "Vika", "https://abrakadabra.fun/uploads/posts/2021-11/1636651859_2-abrakadabra-fun-p-krasivie-avatarki-iz-pinteresta-2.jpg");

            User[] users = { u1, u2 };
            OnlineMeeting m1 = new OnlineMeeting("2021, 10, 20", "Meeting1", "hh-bjghik-kjk", users);
            m1.MakeXmlFile();

            m1.MakeJsonFile();


        }
    }
}