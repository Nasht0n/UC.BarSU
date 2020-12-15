using Common.Entities;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System;

namespace Web.Report
{
    public static class ReportManager
    {
        public static string GenerateBYBlank(string template, string outputFolder, BankYouth bankYouth)
        {
            try
            {
                string output = $"{outputFolder}//BY";
                Document document = new Document();
                document.LoadFromFile(template);
                document.Replace("$CurrentDate", bankYouth.CreateDate.ToShortDateString(), false, true);
                document.Replace("$Surname", bankYouth.Surname, false, true);
                document.Replace("$Firstname", bankYouth.Firstname, false, true);
                document.Replace("$Patronymic", bankYouth.Patronymic, false, true);
                document.Replace("$DateOfBirthday", bankYouth.DateOfBirthday.ToShortDateString(), false, true);
                document.Replace("$MobilePhone", bankYouth.MobilePhone, false, true);
                document.Replace("$Email", bankYouth.Email, false, true);
                document.Replace("$Area", bankYouth.Area, false, true);
                document.Replace("$District", bankYouth.District, false, true);
                document.Replace("$Settlement", bankYouth.Settlement, false, true);
                document.Replace("$YearOfAddmission", bankYouth.YearOfAddmission.ToString(), false, true);
                document.Replace("$Speciality", bankYouth.Speciality, false, true);
                document.Replace("$Qualification", bankYouth.Qualification, false, true);
                document.Replace("$DI", bankYouth.YearOfInclusion.ToString(), false, true);
                document.Replace("$Merit", bankYouth.Merit, false, true);
                document.Replace("$Incentives", bankYouth.Incentives, false, true);
                document.Replace("$PNumber", bankYouth.ProtocolNumber, false, true);
                document.Replace("$PDate", bankYouth.ProtocolDate.ToShortDateString(), false, true);
                document.Replace("$HeadManager", $"{bankYouth.Fullname}, {bankYouth.Post.Trim().ToLower()}, {bankYouth.AcademicDegree.Trim().ToLower()}, {bankYouth.AcademicStatus.Trim().ToLower()}", false, true);
                document.Replace("$CreateDate", bankYouth.CreateDate.ToShortDateString(), false, true);
                document.Replace("$EditDate", bankYouth.EditDate.ToShortDateString(), false, true);
                document.SaveToFile(output, FileFormat.Docx);
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generate BY Blank error : " + ex.InnerException.Message);
                return null;
            }
        }

        public static string GenerateResearchAct(string template, string outputFolder, ImplementationResearchAct act)
        {
            try
            {
                string output = $"{outputFolder}//IAR";
                Document document = new Document();
                document.LoadFromFile(template);
                document.Replace("$ImplementingResult", act.ImplementingResult, false, true);
                document.Replace("$Process", act.Process, false, true);
                document.Replace("$Characteristic", act.Characteristic, false, true);
                document.Replace("$ImplementationForm", act.ImplementationForm, false, true);
                document.Replace("$UnitUsing", act.UnitUsing, false, true);
                Table infoTable = document.Sections[0].Tables[3] as Spire.Doc.Table;
                int indexEmployeeRow = 7;
                foreach (var employee in act.Employees)
                {
                    TableRow row = infoTable.AddRow();
                    Paragraph employeeColumn = row.Cells[1].AddParagraph();
                    TextRange fullname = employeeColumn.AppendText($"{employee.Fullname}, {employee.Post.Trim().ToLower()}");
                    fullname.CharacterFormat.FontSize = 12;
                    infoTable.Rows.Insert(indexEmployeeRow, row);
                    indexEmployeeRow++;
                }
                document.Replace("$FeasibilityOfIntroducing", act.FeasibilityOfIntroducing, false, true);
                foreach (var author in act.Authors)
                {
                    TableRow row = infoTable.AddRow();
                    Paragraph authorColumn = row.Cells[1].AddParagraph();
                    TextRange fullname = authorColumn.AppendText($"{author.Fullname}, {author.Post.Trim().ToLower()}, { author.AcademicDegree.Trim().ToLower()}, { author.AcademicStatus.Trim().ToLower()}");
                    fullname.CharacterFormat.FontSize = 12;
                }
                document.Replace("$HeadManager", act.HeadUnit, false, true);
                document.SaveToFile(output, FileFormat.Docx);
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generate IAR document error : " + ex.InnerException.Message);
                return null;
            }
        }

        public static string GenerateStudentAct(string template, string outputFolder, ImplementationStudentAct act)
        {
            try
            {
                string output = $"{outputFolder}//IAS";
                Document document = new Document();
                document.LoadFromFile(template);
                document.Replace("$Scope", act.Scope, false, true);
                document.Replace("$LengthComission", act.Comissions.Count.ToString(), false, true);
                document.Replace("$Department", act.Department, false, true);
                document.Replace("$Results", act.Result, false, true);
                document.Replace("$Author", act.Author, false, true);
                document.Replace("$ProjectName", act.ProjectName, false, true);
                document.Replace("$PracticalTasks", act.PracticalTasks, false, true);
                document.Replace("$EconomicEfficiency", act.EconomicEfficiency, false, true);
                document.Replace("$ProtocolNumber", act.ProtocolNumber, false, true);
                document.Replace("$ProtocolDate", act.ProtocolDate.ToShortDateString(), false, true);
                Table commissionTable = document.Sections[0].Tables[9] as Table;
                int index = 1;
                foreach (var commission in act.Comissions)
                {
                    TableRow row = commissionTable.AddRow();
                    Paragraph authorColumn = row.Cells[3].AddParagraph();
                    TextRange fullname = authorColumn.AppendText($"{commission.Fullname}, {commission.Post.Trim().ToLower()}");
                    commissionTable.Rows.Insert(index,row);
                    fullname.CharacterFormat.FontSize = 12;
                    index++;
                }
                document.Replace("$RegisterDate", act.ProtocolDate.ToShortDateString(), false, true);
                document.SaveToFile(output, FileFormat.Docx);
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generate IAS document error : " + ex.InnerException.Message);
                return null;
            }
        }
    }
}