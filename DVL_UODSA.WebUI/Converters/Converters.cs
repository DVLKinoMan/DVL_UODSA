using DVL_UODSA.Domain.Entity;
using DVL_UODSA.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVL_UODSA.WebUI.Converters
{
    public static class Converters
    {
        public static List ConvertToList(this CreateListViewModel ViewModel)
        {
            List result = new List
            {
                Description = ViewModel.Description,
                ItemTypeName = ViewModel.ItemTypeName,
                Name = ViewModel.Name,
                IsPrivate = ViewModel.IsPrivate,
                Items = ViewModel.Items.ConvertToListItems()
            };

            if (!string.IsNullOrEmpty(ViewModel.OwnerID))
                result.OwnerID = ViewModel.OwnerID;

            return result;
        }


        public static List<ListItem> ConvertToListItems(this List<ListItemViewModel> ViewModel)
        {
            List<ListItem> result = new List<ListItem>();
            for (int i = 0; i < ViewModel.Count; i++)
                result.Add(ViewModel[i].ConvertToListItem(i));

            return result;
        }

        public static List<SortedListItem> ConvertToSortedListItems(this List<ListItemViewModel> ViewModel)
        {
            List<SortedListItem> result = new List<SortedListItem>();
            for (int i = 0; i < ViewModel.Count; i++)
                result.Add(ViewModel[i].ConvertToSortedListItem(i + 1));

            return result;
        }

        //Do not set All Parameters
        public static SortedListItem ConvertToSortedListItem(this ListItemViewModel ViewModel, int i)
        {
            SortedListItem result = new SortedListItem
            {
                ListItemID = ViewModel.ID,
                SortedNumber = i
            };

            return result;
        }

        public static ListItem ConvertToListItem(this ListItemViewModel ViewModel, int numberInList)
        {
            ListItem result = new ListItem
            {
                Description = ViewModel.Description,
                ImageString = ViewModel.ImageString,
                Name = ViewModel.Name,
                NumberInList = numberInList
            };

            return result;
        }

        public static List<ListViewModel> ConvertToListViewModels(this List<List> lists, string authenticatedUserID)
        {
            List<ListViewModel> result = new List<ListViewModel>();
            for (int i = 0; i < lists.Count; i++)
                result.Add(lists[i].ConvertToListViewModel(authenticatedUserID));

            return result;
        }

        public static ListViewModel ConvertToListViewModel(this List list, string authenticatedUserID)
        {
            ListViewModel result = new ListViewModel
            {
                Description = list.Description,
                ItemTypeName = list.ItemTypeName,
                Name = list.Name,
                Items = list.Items.ConvertToListItemViewModels(),
                ID = list.ID,
                IsPrivate = list.IsPrivate,
                OwnerID = list.OwnerID,
                CanEdit = !string.IsNullOrEmpty(list.OwnerID) && list.OwnerID == authenticatedUserID
            };

            return result;
        }

        public static List<ListItemViewModel> ConvertToListItemViewModels(this IEnumerable<ListItem> listItems)
        {
            List<ListItemViewModel> result = new List<ListItemViewModel>();
            if (listItems != null)
                foreach (var item in listItems)
                    result.Add(item.ConvertToListItemViewModel());

            return result;
        }

        public static ListItemViewModel ConvertToListItemViewModel(this ListItem listItem)
        {
            ListItemViewModel result = new ListItemViewModel
            {
                Description = listItem.Description,
                ImageString = listItem.ImageString,
                Name = listItem.Name,
                ID = listItem.ID,
            };

            return result;
        }

        public static SortedList ConvertToSortedList(this ListViewModel viewModel)
        {
            var sortedList = new SortedList
            {
                BaseListID = viewModel.ID,
                OwnerID = viewModel.OwnerID,
                Items = viewModel.Items.ConvertToSortedListItems()
            };

            return sortedList;
        }

        public static List<SortedListViewModel> ConvertToSortedListViewModels(this List<SortedList> sortedLists, string authenticatedUserID)
        {
            List<SortedListViewModel> result = new List<SortedListViewModel>();
            for (int i = 0; i < sortedLists.Count; i++)
                result.Add(sortedLists[i].ConvertToSortedListViewModel(authenticatedUserID));

            return result;
        }

        public static SortedListViewModel ConvertToSortedListViewModel(this SortedList sortedList, string authenticatedUserID)
        {
            var result = new SortedListViewModel
            {
                BaseList = sortedList.BaseList.ConvertToListViewModel(authenticatedUserID),
                CreatedDateTime = sortedList.CreatedDateTime,
                OwnerID = sortedList.OwnerID,
                ID = sortedList.ID,
                Items = sortedList.Items.ConvertToSortedListItemsViewModel(),
            };

            return result;
        }

        public static List<SortedListItemViewModel> ConvertToSortedListItemsViewModel(this IEnumerable<SortedListItem> sortedListItems)
        {
            var result = new List<SortedListItemViewModel>();
            if (sortedListItems != null)
                foreach (var sortedListItem in sortedListItems)
                    result.Add(sortedListItem.ConvertToSortedListItemViewModel());
            result = result.OrderBy(sl => sl.SortedNumber).ToList();

            return result;
        }

        public static SortedListItemViewModel ConvertToSortedListItemViewModel(this SortedListItem sortedListItem)
        {
            var result = new SortedListItemViewModel
            {
                ID = sortedListItem.ID,
                ListItem = sortedListItem.ListItem.ConvertToListItemViewModel(),
                SortedNumber = sortedListItem.SortedNumber
            };

            return result;
        }
    }
}