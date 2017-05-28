using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using JanitorSystem.ViewModel;
using JanitorSystem.Model;
using JanitorSystem.Facade;

namespace UnitTestJanitorSystem
{
    [TestClass]
    public class UnitTest1
    {
        public ViceListsSingleton singleton
        {
            get { return ViceListsSingleton.Instance; }
            set { /*nothing*/ }
        }

        [TestMethod]
        public void TestGetAssignments()
        {
            singleton.AssignmentList = FacadeService.GetAssignmentList().Result;
            Assert.AreNotEqual(0, singleton.AssignmentList.Count);
            CollectionAssert.AllItemsAreNotNull(singleton.AssignmentList);
        }

        [TestMethod]
        public void TestGetAssignmentsOne()
        {
            singleton.AssignmentList = FacadeService.GetAssignmentList().Result;
        }

        [TestMethod]
        public void TestGetEmployees()
        {
            singleton.EmployeeList = FacadeService.GetEmployeeList().Result;
            Assert.AreNotEqual(0, singleton.EmployeeList.Count);
            CollectionAssert.AllItemsAreNotNull(singleton.EmployeeList);
        }

        [TestMethod]
        public void TestGetAppartments()
        {
            singleton.AppartmentList = FacadeService.GetAppartmentList().Result;
            Assert.AreNotEqual(0, singleton.AppartmentList.Count);
            CollectionAssert.AllItemsAreNotNull(singleton.AppartmentList);
        }

        [TestMethod]
        public void TestGetDepartments()
        {
            singleton.DepartmentsList = FacadeService.GetDepartmentList().Result;
            Assert.AreNotEqual(0, singleton.DepartmentsList.Count);
            CollectionAssert.AllItemsAreNotNull(singleton.DepartmentsList);
        }
    }
}
