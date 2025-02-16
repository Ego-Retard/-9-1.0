using lab;
namespace Testlab9
{
    [TestClass]
    public sealed class Test1
    {
        [TestClass]
        public class DisciplineTests
        {

            [TestMethod]
            public void TestCalcCreditUnit_ValidInput_ReturnsCorrectValue()
            {
                // Arrange
                Discipline discipline = new Discipline("Мат.Анализ", 56, 42);

                // Act
                int result = discipline.CalcCreditUnit();

                // Assert
                Assert.AreEqual(2, result);
            }

            [TestMethod]
            public void TestCalcCreditUnitStatic_ValidInput_ReturnsCorrectValue()
            {
                // Arrange
                Discipline discipline = new Discipline("Мат.Анализ", 56, 42);

                // Act
                int actual = Discipline.CalcCreditUnitStatic(discipline);

                // Assert
                Assert.AreEqual(2, actual);
            }

            [TestMethod]
            public void TestGetDisciplineInfo_ReturnsCorrectString()
            {
                // Arrange
                Discipline discipline = new Discipline("Мат.Анализ", 56, 42);

                // Act
                string actual = discipline.GetDisciplineInfo();

                // Assert
                Assert.AreEqual("Название дисциплины: Мат.Анализ, Часы аудиторной работы: 56, Часы самостоятельной работы: 42", actual);
            }

            [TestMethod]
            public void TestOperatorIncrement_IncreasesContactHoursAndDecreasesSelfHours()
            {
                // Arrange
                Discipline discipline = new Discipline("Мат.Анализ", 56, 42);

                // Act
                Discipline actual = ++discipline;

                // Assert
                Assert.AreEqual("Мат.Анализ", actual.Name);
                Assert.AreEqual(58, actual.ContactHours);
                Assert.AreEqual(40, actual.SelfHours);
            }

            [TestMethod]
            public void TestOperatorNot_CalculatesProportionOfSelfHours()
            {
                // Arrange
                Discipline discipline = new Discipline("Мат.Анализ", 56, 42);

                // Act
                double actual = !discipline;

                // Assert
                Assert.AreEqual(42.0 / (56 + 42), actual);
            }

            //[TestMethod]
            //public void TestExplicitConversionToInt_ReturnsCorrectValue()
            //{
            //    // Arrange
            //    Discipline discipline = new Discipline("Мат.Анализ", 56, 42);

            //    // Act
            //    int actual = (int)(discipline);

            //    // Assert
            //    Assert.AreEqual((56 / 2) - 1, actual); // (56 / 2) - 1 = 27
            //}

            [TestMethod]
            public void TestOperatorGreaterThanOrEqual_CompareCreditUnits()
            {
                // Arrange
                Discipline discipline1 = new Discipline("Мат.Анализ", 56, 42);
                Discipline discipline2 = new Discipline("Дискретная мат", 38, 38);

                // Act
                bool actual = discipline1 >= discipline2;

                // Assert
                Assert.IsTrue(actual);
            }

            [TestMethod]
            public void TestOperatorLessThanOrEqual_CompareCreditUnits()
            {
                // Arrange
                Discipline discipline1 = new Discipline("Мат.Анализ", 56, 42);
                Discipline discipline2 = new Discipline("Дискретная мат", 76, 62);

                // Act
                bool result = discipline1 <= discipline2;

                // Assert
                Assert.IsTrue(result);
            }

            //Проверка на выброс исключений
            [TestMethod]
            public void TestConstructorWithNullName_ThrowsException()
            {
                // Arrange
                string name = null;
                int contactHours = 56;
                int selfHours = 42;

                // Act & Assert
                Assert.ThrowsException<Exception>(() => new Discipline(name, contactHours, selfHours));
            }

            [TestMethod]
            public void TestConstructorWithNegativeContactHours_ThrowsException()
            {
                // Arrange
                string name = "Мат.Анализ";
                int contactHours = -56;
                int selfHours = 42;

                // Act & Assert
                Assert.ThrowsException<Exception>(() => new Discipline(name, contactHours, selfHours));
            }

            [TestMethod]
            public void TestConstructorWithNegativeSelfHours_ThrowsException()
            {
                // Arrange
                string name = "Мат.Анализ";
                int contactHours = 56;
                int selfHours = -42;

                // Act & Assert
                Assert.ThrowsException<Exception>(() => new Discipline(name, contactHours, selfHours));
            }

            //___________Тестирование класса DisciplineArray____________________
            [TestMethod]
            public void TestDefaultConstructor_CreatesEmptyArray()
            {
                // Arrange
                DisciplineArray array = new DisciplineArray();

                // Act
                int length = array.Length;

                // Assert
                Assert.AreEqual(0, length);
            }

            [TestMethod]
            public void TestManualConstructor_CreatesArrayWithGivenValues()
            {
                // Arrange
                string[] names = { "Математика", "Физика", "Программирование" };
                int[] contactHours = { 30, 25, 40 };
                int[] selfHours = { 70, 65, 60 };

                // Act
                DisciplineArray array = new DisciplineArray(names.Length, names, contactHours, selfHours);

                // Assert
                Assert.AreEqual(names.Length, array.Length);
                for (int i = 0; i < names.Length; i++)
                {
                    Assert.AreEqual(names[i], array[i].Name);
                    Assert.AreEqual(contactHours[i], array[i].ContactHours);
                    Assert.AreEqual(selfHours[i], array[i].SelfHours);
                }
            }

            [TestMethod]
            public void TestCopyConstructor_CreatesDeepCopy()
            {
                // Arrange
                DisciplineArray original = new DisciplineArray(3, 10, 50);

                // Act
                DisciplineArray copy = new DisciplineArray(original);

                // Assert
                Assert.AreEqual(original.Length, copy.Length);
                for (int i = 0; i < original.Length; i++)
                {
                    Assert.AreEqual(original[i].Name, copy[i].Name);
                    Assert.AreEqual(original[i].ContactHours, copy[i].ContactHours);
                    Assert.AreEqual(original[i].SelfHours, copy[i].SelfHours);
                }
            }

            [TestMethod]
            public void TestIndexer_ValidIndex_ReturnsCorrectDiscipline()
            {
                // Arrange
                DisciplineArray array = new DisciplineArray(3, 10, 50);

                // Act
                Discipline discipline = array[1];

                // Assert
                Assert.IsNotNull(discipline);
                Assert.AreEqual($"Дисциплина{2}", discipline.Name);
            }

            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void TestIndexer_InvalidIndex_ThrowsException()
            {
                // Arrange
                DisciplineArray array = new DisciplineArray(3, 10, 50);

                // Act
                Discipline discipline = array[5]; // Выход за границы массива
            }

            [TestMethod]
            public void TestShowMethod_PrintsDisciplineInfo()
            {
                // Arrange
                DisciplineArray array = new DisciplineArray(2, 10, 50);
                var consoleOutput = new System.IO.StringWriter();
                Console.SetOut(consoleOutput);

                // Act
                array.Show();

                // Assert
                string output = consoleOutput.ToString();
                Assert.IsTrue(output.Contains("Название дисциплины"));
                Assert.IsTrue(output.Contains("Часы аудиторной работы"));
                Assert.IsTrue(output.Contains("Часы самостоятельной работы"));
            }




            //______________Тестирование функции CalcWeightAverageValue____________________

            [TestClass]
            public class ProgramTests
            {
                [TestMethod]
                public void TestCalcWeightAverageValue_EmptyArray_ReturnsZero()
                {
                    // Arrange
                    DisciplineArray disciplines = new DisciplineArray(0, 0, 0);

                    // Act
                    double actual = lab.Program.CalcWeightAverageValue(disciplines);

                    // Assert
                    Assert.AreEqual(0, actual);
                }

                [TestMethod]
                public void TestCalcWeightAverageValue_ValidData_ReturnsCorrectValue()
                {
                    // Arrange
                    DisciplineArray disciplines = new DisciplineArray(3, 10, 50);
                    disciplines[0] = new Discipline("Дискретная мат", 30, 70);
                    disciplines[1] = new Discipline("Мат.Анализ", 25, 65);
                    disciplines[2] = new Discipline("Программирование", 40, 60);

                    // Act
                    double actual = lab.Program.CalcWeightAverageValue(disciplines);

                    // Assert
                    int totalCredits = disciplines[0].CalcCreditUnit() + disciplines[1].CalcCreditUnit() + disciplines[2].CalcCreditUnit();
                    int totalHours = (disciplines[0].SelfHours + disciplines[0].ContactHours) +
                                     (disciplines[1].SelfHours + disciplines[1].ContactHours) +
                                     (disciplines[2].SelfHours + disciplines[2].ContactHours);

                    double expected = totalCredits / (double)totalHours * 38;
                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}

            
