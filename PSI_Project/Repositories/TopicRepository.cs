﻿using PSI_Project.DAL;

namespace PSI_Project.Repositories
{
    public class TopicRepository : BaseRepository<Topic>
    {
        protected override string DbFilePath => "..//PSI_Project//DB//topic.txt";

        public TopicRepository() : base()
        {
            Console.WriteLine($"Loaded {Items.Count} topics.");
            foreach (var topic in Items)
            {
                Console.WriteLine($"Topic: {topic.Name}, Subject: {topic.SubjectName}");
            }
        }

        protected override string ItemToDbString(Topic item)
        {
            return $"{item.Id};{item.SubjectName};{item.Name};";
        }

        protected override Topic StringToItem(string dbString)
        {
            String[] topicFields = dbString.Split(";");
            if (topicFields.Length < 3)
            {
                throw new FormatException($"Unexpected data format for topic: {dbString}");
            }

            return new Topic(topicFields[2], topicFields[1]);
        }

        public List<Topic> GetTopicsBySubjectName(string subjectName)
        {
            return Items.Where(topic => topic.SubjectName.Equals(subjectName)).ToList();
        }

        public Topic? GetItemByName(string topicName)
        {
            return Items.FirstOrDefault(topic => topic.Name.Equals(topicName));
        }
    }
}