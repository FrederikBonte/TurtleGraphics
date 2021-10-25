using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class CriteriumGroup
    {
        private readonly int id;
        private string name;
        private Project project;
        private CriteriumGroup parent;
        private readonly List<ProjectCriterium> criteria = new List<ProjectCriterium>();
        private readonly List<CriteriumGroup> subgroups = new List<CriteriumGroup>();
        private byte method; // 1=sum, 2=avg, 3=min, 4=max, other
        private bool saved = true;

        public CriteriumGroup(int id = -1, byte method = 1, string name = "MainGroup")
        {
            this.id = id;
            this.method = method;
            this.saved = (id != -1);
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
            if (this.parent!=null)
            {
                this.parent.setDirty();
            } else if (this.project!=null)
            {
                this.project.setDirty();
            }
        }

        public int getId()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public byte getMethod()
        {
            return this.method;
        }

        public void setMethod(byte method)
        {
            this.method = method;
        }

        public int getScore()
        {
            return -1;
        }

        public CriteriumGroup getParentGroup()
        {
            return this.parent;
        }

        public Project getProject()
        {
            return this.project;
        }

        internal void Add(CriteriumGroup group)
        {
            this.subgroups.Add(group);
            group.setParent(this);
        }

        internal void Add(ProjectCriterium criterium)
        {
            this.criteria.Add(criterium);
            setDirty();
        }

        internal void setParent(CriteriumGroup parent)
        {
            this.parent = parent;
        }

        internal void setProject(Project project)
        {
            this.project = project;
        }

        internal IEnumerable<ProjectCriterium> getCriteria()
        {
            return this.criteria.AsReadOnly();
        }
    }
}
