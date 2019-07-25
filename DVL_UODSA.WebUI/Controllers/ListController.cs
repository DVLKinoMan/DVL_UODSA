using DVL_UODSA.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DVL_UODSA.WebUI.Converters;
using DVL_UODSA.Domain.Abstract;
using DVL_UODSA.Domain.Concrete;
using Microsoft.AspNet.Identity;

namespace DVL_UODSA.WebUI.Controllers
{
    public class ListController : Controller
    {
        private IListRepository listRepository = new ListRepository();
        //private IUserRepository userRepostiory = new UserRepository();
        private ISortedListRepository sortedListRepository = new SortedListRepository();

        // GET: List
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            List<ListViewModel> lists = listRepository.GetActiveLists(userID).ConvertToListViewModels(userID);
            foreach (var list in lists)
                list.CanSort = sortedListRepository.CanSortList(list.ID, userID);

            return View(lists);
        }

        [HttpPost]
        public ActionResult Index(int listID)
        {
            listRepository.DeleteListByID(listID);

            return RedirectToAction("Index");
        }

        public ActionResult CreateList()
        {
            return View();
        }

        public ActionResult ViewList(int listID)
        {
            var listViewModel = listRepository.GetListByID(listID).ConvertToListViewModel(User.Identity.GetUserId());

            return View(listViewModel);
        }

        [HttpPost]
        public ActionResult SaveList(CreateListViewModel list)
        {
            list.OwnerID = User.Identity.GetUserId();
            //save in database
            listRepository.AdddList(list.ConvertToList());

            return RedirectToAction("Index");
        }

        public ActionResult SortList(int listID)
        {
            ViewBag.listID = listID;

            return View();
        }

        [HttpPost]
        public JsonResult GetList(int listID)
        {
            var listViewModel = listRepository.GetListByID(listID).ConvertToListViewModel(User.Identity.GetUserId());

            return Json(listViewModel);
        }

        [HttpPost]
        public ActionResult SaveSortedList(ListViewModel list)
        {
            list.OwnerID = User.Identity.GetUserId();
            sortedListRepository.SaveSortedList(list.ConvertToSortedList());

            return RedirectToAction("MySortedLists");
        }

        public ActionResult MySortedLists()
        {
            var userID = User.Identity.GetUserId();
            var mySortedLists = sortedListRepository.GetActiveSortedListsByOwnerID(userID).ConvertToSortedListViewModels(userID);
            foreach (var sortedList in mySortedLists)
                sortedList.BaseList.CanSort = sortedListRepository.CanSortList(sortedList.BaseList.ID, userID);

            return View(mySortedLists);
        }

        public ActionResult ViewSortedList(int? sortedListID)
        {
            var userID = User.Identity.GetUserId();
            var sortedList = sortedListRepository.GetActiveSortedListByID((int)sortedListID).ConvertToSortedListViewModel(userID);

            return View(sortedList);
        }

        [HttpPost]
        public ActionResult DeleteSortedList(int sortedListID)
        {
            sortedListRepository.DeleteSortedListByID(sortedListID);

            return RedirectToAction("MySortedLists");
        }

        public ActionResult ListStatistics(int listID)
        {
            var sortedListItems = sortedListRepository.GetActiveSortedListsByBaselistID(listID).SelectMany(sl => sl.Items).GroupBy(slItem => slItem.ListItemID)
                .Select(gr => new ListItemStatisticsViewModel
                {
                    ListItem = gr.First().ListItem.ConvertToListItemViewModel(),
                    SortedNumbersSum = gr.Sum(slItem => slItem.SortedNumber)
                }).OrderBy(item => item.SortedNumbersSum).ToList();
            //var listViewModel = listRepository.GetListByID(listID).ConvertToListViewModel(User.Identity.GetUserId());
            for (int i = 1; i <= sortedListItems.Count; i++)
                sortedListItems[i - 1].SortedNumber = i;

            var result = new ListStaticsViewModel { Items = sortedListItems };

            return View(result);
        }
    }
}