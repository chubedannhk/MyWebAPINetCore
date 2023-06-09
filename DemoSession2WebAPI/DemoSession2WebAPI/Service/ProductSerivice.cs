﻿using DemoSession2WebAPI.Models;

namespace DemoSession2WebAPI.Service;

public interface ProductSerivice
{
    // su dung khong dc
    public List<Product> findAll();
    // phai dung dynamic
    public dynamic findAll2();

    public dynamic findById(int id);
    public Product findbyId(int id);
    public dynamic searchBykeyword(string keyword);
    public dynamic searchbyCategoryId(int catetoryId);

    public bool Created(Product product);

    public bool Delete(int id);

    public bool Update(Product product);

}
