using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace System.Quests.Tests
{
    public class QuestTest
    {
        private Guid sampleItem = Guid.NewGuid();
        private Guid legendaryItem = Guid.NewGuid();

        [Fact]
        public void CreateSampleQuest()
        {
            Quest quest = new Quest()
            {
                Name = "Sample Quest",
                Description = "This is a sample quest to show how the quest system works.",
                Expiration = 0,
            };

            quest.Add(new Objective()
            {
                Name = "Sample Objective",
                Description = "This is a sample objective for the sample quest.",
                Type = "Item",
                Expiration = 0,
                Priority = 0,
                Step = 0,
                Data = sampleItem,
            });

            quest.Add(new Requirement()
            {
                Name = "Sample Requirement",
                Description = "This is a sample requirement for the sample quest.",
                Amount = 1,
                Type = "Level",
            });

            quest.Add(new Reward()
            {
                Name = "Sample Reward",
                Description = "This is a sample reward for the sample quest.",
                Amount = 1,
                Type = "Monetary",
            });

            Assert.Equal(0, quest.Progress);
        }

        [Fact]
        public void ProcessSampleObjective()
        {
            Quest quest = new Quest()
            {
                Name = "Sample Quest",
                Description = "This is a sample quest to show how the quest system works.",
                Expiration = 0,
            };

            quest.Add(new Objective()
            {
                Name = "Sample Objective",
                Description = "This is a sample objective for the sample quest.",
                Type = "Item",
                Expiration = 0,
                Priority = 0,
                Step = 0,
                Data = sampleItem,
            });

            quest.Add(new Requirement()
            {
                Name = "Sample Requirement",
                Description = "This is a sample requirement for the sample quest.",
                Amount = 1,
                Type = "Level",
            });

            quest.Add(new Reward()
            {
                Name = "Sample Reward",
                Description = "This is a sample reward for the sample quest.",
                Amount = 1,
                Type = "Monetary",
            });

            Assert.Equal(0, quest.Progress);

            quest.Process(new ObjectiveEventArgs()
            {
                Type = "Item",
                Data = legendaryItem,
                Amount = 1,
            });
        }

        //[Fact]
        //public async Task CreateQuestFromJson()
        //{
        //    using (var fileStream = File.Open("sample_quest.json", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
        //    {
        //        using (var streamReader = new StreamReader(fileStream))
        //        {
        //            string fileContent = await streamReader.ReadToEndAsync();

        //            Quest quest = JsonConvert.DeserializeObject<Quest>(fileContent);
        //        }
        //    }
        //}
    }
}
