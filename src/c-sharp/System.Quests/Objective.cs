using System;
using System.Collections.Generic;
using System.Text;

namespace System.Quests
{
    public sealed class Objective
    {
        private double _progress = 0;

        public Objective()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Expiration { get; set; }
        public int Priority { get; set; }
        public int Step { get; set; }

        public double Amount { get; set; } = 1;        
        public double Progress { get { return _progress / Amount; } set { _progress = value; } }
        public Guid Data { get; set; }

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
            if (Type.Equals(args.Type))
            {
                if (Data == args.Data)
                {
                    _progress += args.Amount;
                }
            }
            else
            {
                foreach(var objective in Objectives)
                {
                    objective.Process(args);
                }
            }
        }

        private double GetProgress()
        {
            double progress = _progress / Amount;

            foreach(var objective in Objectives)
            {
                progress += objective.Progress;
            }

            return ((progress * 100) / (Amount + Objectives.Count));
        }
    }
}
