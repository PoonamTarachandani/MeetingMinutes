using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MeetingMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Meeting Minutes Management Software");
            Console.WriteLine("1-Create Meeting");
            Console.WriteLine("2-View Team");
            Console.WriteLine("3-Exit");
            Console.WriteLine("Select Item from menu by number");
            int choose = int.Parse(Console.ReadLine());

            if (choose == 1)
            {
                Console.WriteLine("Create Meeting");
                Console.WriteLine("Team member recording the minutes?");
                string mins = Console.ReadLine();
                Console.WriteLine("Team member leading the meeting?");
                string leader = Console.ReadLine();
                Console.WriteLine("Date for the meeting-MMDDYY?");
                int date = int.Parse(Console.ReadLine());
                // string date1 = date.ToString("MM\DD\YY");
                Console.WriteLine("Type of meeting?");
                List<string> TypeOfMeeting = new List<string>();
                TypeOfMeeting.Add("Marketing Team");
                TypeOfMeeting.Add("Admin Team");
                TypeOfMeeting.Add("All Team");
                int index = 1;
                foreach (string list in TypeOfMeeting)
                {
                    Console.WriteLine(index + "." + list);
                    index++;
                }
                Console.WriteLine("Select type of meeting by giving number");
                int num = int.Parse(Console.ReadLine());
                string SelectedType = TypeOfMeeting[num - 1];
                Console.WriteLine("Meeting topic");
                string topic = Console.ReadLine();
                Console.WriteLine("Notes for the topic");
                string notes = Console.ReadLine();
                string Alltext = "";

                Alltext += "We Can Code It";
                Alltext += "\r\n50,Public square,Suite-200";
                Alltext += "\r\nCleveland-OH,44113";
                Alltext += "\r\n****************************";
                Alltext += "\r\nMeeting Minutes";
                Alltext += "\r\n****************************";
                Alltext += "\r\nMinutes Recorder : " + mins;
                Alltext += "\r\nMeeting Leader : " + leader;
                Alltext += "\r\nType of meeteing : " + SelectedType;
                Alltext += "\r\nMeeting Topic : " + topic;
                Alltext += "\r\nMeeting Notes : " + notes;
              

                string NewTopic = "";
                string NewNotes = "";
                Console.WriteLine("would you like to enter notes for another topic");
                string answer = Console.ReadLine();
                while (answer == "yes")
                {
                    
                    Console.WriteLine("Topic name?");
                    NewTopic = Console.ReadLine();
                    Alltext += "\r\nAnother topic :" + NewTopic;
                    Console.WriteLine("Notes for new topic");
                    NewNotes = Console.ReadLine();
                    Alltext += "\r\nNotes for  new topic :" + NewNotes;
                    Console.WriteLine("would you like to enter notes for another topic");
                    answer = Console.ReadLine();



                }

                WriteText("Minutes" + date + ".txt", Alltext);
                string textdata = ReadText("Minutes" + date + ".txt");
                Console.WriteLine(textdata);

               }

             else if (choose == 2)
            {
                string Marketing = "(Marketing)";
                string Admin = "(Admin)";
                string AllTeam = "(AllTeam)";
                Dictionary<string, string> Team = new Dictionary<string, string>();

                Team.Add("John Joseph", Marketing);
                Team.Add("Anil Hernandez", Marketing);
                Team.Add("Lina nair", Marketing);
                Team.Add("Asha waterstreet", Admin);
                Team.Add("Julia hummel", Admin);
                Team.Add("Veena lani", Admin);
                Team.Add("Pepe Rodri", AllTeam);
                Team.Add("carol negi", AllTeam);
                Team.Add("Anju mir", AllTeam);


                foreach (KeyValuePair<string, string> members in Team)

                    Console.WriteLine(members);
                Console.WriteLine("enter team name to print team members?");
                string teamName = Console.ReadLine();
                PrintTeamMembers(Team, teamName);

            }

            else if (choose == 3)
            {
                Console.WriteLine("Goodbye");
            }


        }

        static void PrintTeamMembers(Dictionary<string,string> TeamMember,string TeamName)
        {
            foreach (KeyValuePair<string, string> member in TeamMember)
            {
                if ("(" + TeamName.ToLower() + ")" == member.Value.ToLower())
                {
                    Console.WriteLine(member);
                }
            }
        }

        static void WriteText(string FilePath, string text)

        {
            StreamWriter writer = new StreamWriter(FilePath);
            using (writer)
            {
                writer.WriteLine(text);
            }
        }
        static string ReadText(string FilePath)
        {
            string line = "";
            StreamReader reader = new StreamReader(FilePath);
            using (reader)
            {
                line = reader.ReadToEnd();
                return line;
            }




        }
    }
}



