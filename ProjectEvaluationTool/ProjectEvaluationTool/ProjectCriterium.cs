using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class ProjectCriterium
    {
        private readonly CriteriumGroup group;
        private Criterium criterium;
        private bool active;
        private float weight;
        private bool saved = false;

        public ProjectCriterium(CriteriumGroup group, Criterium criterium, float weight, bool active = true)
        {
            this.group = group;
            this.criterium = criterium;
            this.weight = weight;
            this.active = active;
        }

        public void store()
        {
            this.saved = true;
        }

        public bool isSaved()
        {
            return this.saved;
        }

        public void setDirty()
        {
            this.saved = false;
            this.group.setDirty();
        }

        public CriteriumGroup getGroup()
        {
            return this.group;
        }

        public Criterium getCriterium()
        {
            return this.criterium;
        }

        public void setCriterium(Criterium criterium)
        {
            this.criterium = criterium;
        }

        public bool isActive()
        {
            return this.active;
        }

        public void setActive(bool active)
        {
            this.active = active;
        }

        public void makeActive()
        {
            this.setActive(true);
        }

        public void makeInactive()
        {
            this.setActive(false);
        }

        public float getWeight()
        {
            return this.weight;
        }

        public void setWeight(float weight)
        {
            this.weight = weight;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.criterium.ToString());
            result.Append(" (");
            if (isActive())
            {
                result.Append(getWeight());
                result.Append(")");
            } else
            {
                result.Append("inactive)");
            }
            return result.ToString();
        }
    }
}
