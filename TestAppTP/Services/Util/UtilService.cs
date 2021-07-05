using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAppTP.Models;
using TestAppTP.Models.DB;

namespace TestApp.BLL.Util
{
    public class UtilService : IUtilService
    {
        public int Restock(List<int> itemCount, int target)
        {
            var result = 0;
            try
            {

                var sum = itemCount.Sum(item => item);
                if (sum > target)
                {
                    result = sum - target;
                }
                return result;

            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public double ResponseNotes(StudentViewModel Model)
        {
            double average = 0;
            try
            {
                using (var context = new TestTPContext())
                {

                    var NewStudent = new NotasEstudiante
                    {
                        Documento = Model.Document.ToString(),
                        Nombres = Model.Name,
                        Apellidos = Model.LastName,
                        Nota1 = Model.Note1.ToString(),
                        Nota2 = Model.Note2.ToString(),
                        Nota3 = Model.Note3.ToString()
                    };
                    context.NotasEstudiante.Add(NewStudent);
                    context.SaveChanges();
                    average = (Convert.ToDouble(Model.Note1) + Convert.ToDouble(Model.Note2) + Convert.ToDouble(Model.Note3)) / 3;
                    var Query = context.NotasEstudiante.FirstOrDefault(x => x.Documento == NewStudent.Documento);
                    if (Query != null)
                    {

                        var NewStudentAverage = new EstudiantePromedio
                        {
                            IdEstudiante = Query.Id,
                            PromedioNotas = average.ToString()
                        };
                        context.EstudiantePromedio.Add(NewStudentAverage);
                        context.SaveChanges();
                    }
                }
                return average;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
