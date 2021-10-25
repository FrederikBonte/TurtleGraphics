using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class Project
    {
        private string name, description;
        private int id, semester, stars;
        private bool active, blueprint;
        private readonly CriteriumGroup group;
        private bool saved = true;

        public Project(int id, string name, string description, int semester, int stars, CriteriumGroup group, bool active = true, bool blueprint = false)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.semester = semester;
            this.stars = stars;
            this.active = active;
            this.blueprint = blueprint;
            this.group = group;
            this.saved = group.isSaved();
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
        }

        public void rename(string name, string description)
        {
            this.name = name;
            this.description = description;
            setDirty();
        }

        public string getName()
        {
            return this.name;
        }

        public string getDescription()
        {
            return this.description;
        }

        public void setDescription(string description)
        {
            this.description = description;
            setDirty();
        }

        public int getSemester()
        {
            return this.semester;
        }

        public int getStars()
        {
            return this.stars;
        }

        public void setStars(int stars)
        {
            this.stars = stars;
            setDirty();
        }
        
        public void setSemester(int semester)
        {
            this.semester = semester;
            setDirty();
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

        public bool isBluePrint()
        {
            return this.blueprint;
        }

        public void setBluePrint(bool blueprint)
        {
            this.blueprint = blueprint;
        }

        public void makeBluePrint()
        {
            this.setBluePrint(true);
            setDirty();
        }

        public CriteriumGroup getGroup()
        {
            return this.group;
        }

        public override string ToString()
        {
            return this.name+" S"+semester+""+stars;
        }
    }
}
