namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NameAndObject 
    {
        public string Name {
            get;
            set;
        }

        public NameAndObject(string name)
        {
            Name = name;
        
        }
    }
    public abstract class Book : NameAndObject {
        public Book(string name) : base(name)
        {
        }
        public abstract Statistics GetStatistics() ;
        public abstract void AddGrade(double grade);
        public abstract event GradeAddedDelegate GradeAdded;
    }

    public interface  IBook
    {
        public void AddGrade(double grade); 
        Statistics GetStatistics();
        event GradeAddedDelegate GradeAdded;
          public string Name {
            get;
            set;
        }
      
    }

    public class InMemoryBook: Book, IBook
    {
       public InMemoryBook (string name) : base(name) {
              this.grades = new List<double>();
              Name = name;
              
         }
        public override void AddGrade(double grade) {
            grades.Add(grade);
            if (GradeAdded != null) {
                GradeAdded(this, new EventArgs());
            }
            System.Console.WriteLine($"add grade = {grade}");
            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            for (var index = 0; index < grades.Count; index++) {
                result.Add(grades[index]);
            } 
           
            return result;
        }

         private List <double> grades;
        
         public override event GradeAddedDelegate GradeAdded;

    }


   public class DiskBook: Book, IBook
    {
       public DiskBook (string name) : base(name) {
            
         }
        public override void AddGrade(double grade) {
          
          using(var writer = File.AppendText($"{Name}.txt"))
          {
            writer.WriteLine(grade);
            if(GradeAdded != null) {
                GradeAdded(this,new EventArgs());
            }
          }
            // sera automatiquement fait grace au using
            //   writer.Close(); 
            //   writer.Dispose();
         }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null) {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            
            return result;
        }

        
      
         public override event GradeAddedDelegate GradeAdded;
       //private List <double> grades;
    }    

    
}