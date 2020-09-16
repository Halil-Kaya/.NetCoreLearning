using System;
using System.Collections.Generic;
using shopapp.entity;

namespace temelOzellikler.ViewModels
{


public class PageInfo{

    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int CurrentPage { get; set; }
    public string CurrentCategory { get; set; }

    public int TotalPages(){
        return (int) Math.Ceiling(((decimal) TotalItems/ItemsPerPage));
    }

}

    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> products { get; set; }


    }
}