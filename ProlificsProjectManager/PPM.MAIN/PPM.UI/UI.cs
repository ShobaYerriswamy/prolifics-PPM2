using System;
using System.Text.RegularExpressions;

using ProlificsProjectManager.PPM.MAIN.PPM.MODEL;
using ProlificsProjectManager.PPM.MAIN.PPM.DOMAIN;


namespace ProlificsProjectManager.PPM.MAIN.PPM.UI
{
    public class viewing
    {
        public void view()
        {
            Console.WriteLine(" ======= HELLO PROLIFICS EMPLOYEE ======= ");
            Console.WriteLine("Enter 1 to Adding Project");
            Console.WriteLine("Enter 2 to View all Projects");
            Console.WriteLine("Enter 3 to Adding Employee");
            Console.WriteLine("Enter 4 to View all Employees");
            Console.WriteLine("Enter 5 to Adding Role");
            Console.WriteLine("Enter 6 to View all Roles");
            Console.WriteLine("Enter 7 for searching Project");
            Console.WriteLine("Enter 8 for searching Project through ID");
            Console.WriteLine("Enter 9 to View all Projects");
            Console.WriteLine("Enter 10 for Adding Employees to Project");
            Console.WriteLine("Enter 11 for view all Employees who added to Project");
            Console.WriteLine("Enter 'S' to QUIT the application");
       
            ProjectManager PM =  new ProjectManager();
            EmployeeManager EM = new EmployeeManager();
            RoleManager RM = new RoleManager();
            Project project = new Project();
            Employee employee = new Employee();

            RM.RoleList.Add(new Role(1, "Software Engineer"));
            RM.RoleList.Add(new Role(2, "Associate Software Engineer"));
            RM.RoleList.Add(new Role(3, "Trainee Software Engineer"));
            RM.RoleList.Add(new Role(4, "Technical Lead"));

            Boolean error = false;

            Regex phnumber = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");
            Regex Email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            var UserInput = Console.ReadLine();

            while (true)
            {
                repeat:

                switch (UserInput)
                {
                    case "1":
                        do
                        {
                            try
                            {
                                Console.WriteLine("Enter the Project Id");
                                int id = Convert.ToInt32(Console.ReadLine());
                                for (int i=0; i<=PM.Projects.Count; i++)
                                {
                                    if (id==project.id)
                                    {
                                        Console.WriteLine("Thr id already exists try new id");
                                        Console.WriteLine("Enter any key to try again");
                                        Console.WriteLine("Enter 'S' to QUIT the application");
                                        string idTry=Console.ReadLine();
                                        if (idTry=="x")
                                        {
                                            goto breakage;
                                        }
                                    }
                                }
                                Console.WriteLine("Enter the name of Project");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter the Start Date of Project");
                                string start = Console.ReadLine();
                                Console.WriteLine("Enter the End Date of Project");
                                string end = Console.ReadLine();

                                Project proj1 = new Project(name, start, end, id);
                                PM.AddingProjects(proj1);
                                project = proj1;
                                
                                Console.WriteLine("Added Successfully");
                                Console.WriteLine("Enter any key to get Main Menu");
                                Console.ReadLine();
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("\nError : only use Numbers for Id");
                                Console.WriteLine("Enter any key to try again");
                                Console.WriteLine("Enter any key to get Main Menu");
                            
                                UserInput= Console.ReadLine();
                                if(UserInput == "x")
                                {
                                    break;
                                }
                                error = true;
                            }
                        }
                        while(error);
                        breakage:
                        break;
                        

                    case "2":
                        PM.displayAllProjects();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "3":
                    
                        Console.WriteLine("Enter the Id of Employee");
                        int empId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Employee fist name");
                        var fname = Console.ReadLine();
                        Console.WriteLine("Enter Employee last name");
                        var lname = Console.ReadLine();
                        Email:
                            Console.WriteLine("Enter Employee Email id");
                            var EMAIL= Console.ReadLine();
                            if(!Email.IsMatch(EMAIL))
                            {
                                Console.WriteLine("Invalid Email Format");
                                Console.WriteLine("Enter any key to retry again");
                                Console.WriteLine("Enter \"x\" to exit to main menu");
                                var emailread=Console.ReadLine();
                                if(emailread=="x")
                                {
                                    break;
                                }
                                else
                                {
                                    goto Email;
                                }
                            }

                        mobile:
                            Console.WriteLine("Enter Employee mobile number");
                            var mobile = Console.ReadLine();
                            if(!phnumber.IsMatch(mobile))
                            {
                                Console.WriteLine("Invalid mobile number format");
                                Console.WriteLine("Enter any key to retry again");
                                Console.WriteLine("Enter \"x\" to exit to main menu");
                                var mobread=Console.ReadLine();
                                if(mobread=="x")
                                {
                                    break;
                                }
                                else
                                {
                                    goto mobile;
                                }
                                
                            }
                            Console.WriteLine("Enter Employee address");
                            var address = Console.ReadLine();
                            Console.WriteLine("Select 1 for assinging employee with new role name and new role id");
                            Console.WriteLine("Select 2 for assinging existing role to the employee");
                            int selection = Convert.ToInt32(Console.ReadLine());

                            if(selection == 1)
                            {
                                try
                                {
                                    Console.WriteLine("Enter the Role Id");
                                    int roleID = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter the name of Role");
                                    string role_name = Console.ReadLine();
                                    Console.WriteLine(role_name);

                                    Role newRole = new Role(roleID, role_name);
                                    RM.RoleAdd(newRole);

                                    Employee emp = new Employee(empId, fname, lname, EMAIL, mobile, address, roleID,  role_name);
                                    EM.AddEmp(emp);
                                    employee = emp;
                                    Console.WriteLine("Added Successfully");
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine("Role id should be in numbers only");
                                }
                            }

                            else if (selection == 2)
                            {
                                try
                                {
                                    RM.dispalyRole();
                                    Console.WriteLine("Select Role id from above list to assign role to employee");
                                    int role1 = Convert.ToInt32(Console.ReadLine());
                                    string? roleNAME1 = null;
                                    switch (role1)
                                    {
                                        case 1:
                                            roleNAME1 = "Software Engineer";
                                        break;
                                        case 2:
                                            roleNAME1 = "Associate Software Engineer";
                                        break;
                                        case 3:
                                            roleNAME1 = "Trainee Software Engineer";
                                        break;
                                        case 4:
                                            roleNAME1 = "Technical Lead";
                                        break;
                                        default:
                                            Console.WriteLine("Invalid Entry");
                                        break;
                                    }
                            
                                    Employee emp1 = new Employee(empId, fname, lname, EMAIL, mobile, address, role1, roleNAME1);
                                    EM.AddEmp(emp1);
                                    employee = emp1;
                                    Console.WriteLine("Added Successfully!");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Emp id can only be in numbers");
                                }
                            }
                            
                            Console.WriteLine("Enter any key to get to main menu");
                            Console.ReadLine();
                            break;
                    
                    case "4":
                        EM.ShowEmp();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "5":
                        try
                        {
                            Console.WriteLine("Enter the Role Id");
                            int roleID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the name of Role");
                            string role_name = Console.ReadLine();
                            Console.WriteLine(role_name);
                            Role newRole = new Role(roleID, role_name);
                            RM.RoleAdd(newRole);
                            Console.WriteLine("Added Successfully!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Role Id should be in Numbers only");
                        }

                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "6":
                        RM.dispalyRole();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "7":
                        Console.WriteLine("Type to Search for Project");
                        UserInput = Console.ReadLine();
                        PM.SearchProject(UserInput);
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;
                    
                    case "8":
                        try
                        {
                            Console.WriteLine("Search via Project id");
                            Console.WriteLine("Enter the id of project");
                            int eid = Convert.ToInt32(Console.ReadLine());
                            PM.ShowProject(eid);
                            Console.WriteLine("Enter any key to get Main Menu");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Id should be in Numbers only");
                        }
                        break;

                    case "9":
                        PM.displayAllProjects();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "10":

                        Console.WriteLine("");
                        PM.displayAllProjects();
                        Console.WriteLine("Above are the available projects");
                        Console.WriteLine();
                        EM.ShowEmp();
                        Console.WriteLine("Above are the available employees");
                        Console.WriteLine("Enter the Project ID from above list exactly");
                        int PROJId =Convert.ToInt32(Console.ReadLine());
                        if(PM.exist(PROJId))
                        {
                            Console.WriteLine("Enter the Id of Employee to add into project");
                            int EmpId = Convert.ToInt32(Console.ReadLine());
                        
                            if(EM.exist(EmpId))
                            {
                                employee = EM.eDetails(EmpId);
                                PM.emptopro(PROJId,employee);
                                Console.WriteLine("Added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Employee");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Entry");
                        }
                        var Read = Console.ReadLine();
                        break;

                    case "11": 
                        Console.WriteLine("Enter Project Id");
                        int pid =Convert.ToInt32(Console.ReadLine());
                        PM.display();
                        Console.WriteLine("Enter any key to get Main Menu");
                        break;

                    case "S":
                        return;

                    default:
                        Console.WriteLine("Invalid Entry");
                        break; 
                }

                    Console.WriteLine(" ======= LIST ======= ");
                    Console.WriteLine("Enter 1 for Adding Project");
                    Console.WriteLine("Enter 2 to Show all projects");
                    Console.WriteLine("Enter 3 for Adding Employee");
                    Console.WriteLine("Enter 4 for Viewing all Employees");
                    Console.WriteLine("Enter 5 for Adding Role");
                    Console.WriteLine("Enter 6 for Viewing all Roles");
                    Console.WriteLine("Enter 7 for searching Project");
                    Console.WriteLine("Enter 8 for searching Project through ID");
                    Console.WriteLine("Enter 9 to View all Projects");
                    Console.WriteLine("Enter 10 for Adding Employees to Project");
                    Console.WriteLine("Enter 11 for view all Employees who added to Project");
                    Console.WriteLine("Enter 'S' to QUIT the application");
                
                    Console.WriteLine("Select Optaions from above List");
                    UserInput = Console.ReadLine();
                    Console.ReadLine();
            }    
        }
    }
}