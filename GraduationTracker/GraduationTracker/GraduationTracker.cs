using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            var average = 0;
            foreach (var diplomaRequirement in diploma.Requirements)
            {
                var courseRequirement = Repository.GetRequirement(diplomaRequirement);
                var studentMark = student.Courses.Single(c=> c.Name==courseRequirement.Name).Mark;
                average += studentMark;
            }

            average /= student.Courses.Length;

            if (average < 50) return new Tuple<bool, STANDING>(false, STANDING.Remedial);
            else if (average < 80) return new Tuple<bool, STANDING>(true, STANDING.Average);
            else if (average < 95) return new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);
            else return new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
        }

        public Tuple<bool, Student> HasCredit(Diploma diploma, Student student)
        {
            var credits = 0;
            foreach (var diplomaRequirement in diploma.Requirements)
            {
                var courseRequirement = Repository.GetRequirement(diplomaRequirement);
                var studentMark = student.Courses.Single(c => c.Name == courseRequirement.Name).Mark;
                if (studentMark > courseRequirement.MinimumMark)
                {
                    credits += courseRequirement.Credits;
                }
            }
            if (credits < 4) return new Tuple<bool, Student>(false, student);
            else return new Tuple<bool, Student> (true, student);
        }
    }
}
