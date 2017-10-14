using System;
using System.Collections.Generic;
using System.Text;

namespace System.Quests
{
    public sealed class Quest
    {
        public Quest()
        {

        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanExpire => Expiration > 0;
        public double Expiration { get; set; }

        public double Progress { get { return GetProgress(); } }

        public List<Objective> Objectives { get; set; } = new List<Objective>();
        public List<Requirement> Requirements { get; set; } = new List<Requirement>();
        public List<Reward> Rewards { get; set; } = new List<Reward>();

        public void Add(Objective objective)
        {
            if (!Objectives.Contains(objective))
            {
                Objectives.Add(objective);
            }
        }        
        public void Add(Requirement requirement)
        {
            if (!Requirements.Contains(requirement))
            {
                Requirements.Add(requirement);
            }
        }        
        public void Add(Reward reward)
        {
            if (!Rewards.Contains(reward))
            {
                Rewards.Add(reward);
            }
        }

        public void Process(ObjectiveEventArgs args)
        {
            foreach (var objective in Objectives)
            {
                objective.Process(args);
            }
        }

        private double GetProgress()
        {
            double progress = 0;

            foreach(var objective in Objectives)
            {
                progress += objective.Progress;
            }

            return (progress * 100) / Objectives.Count;
        }
    }
}
