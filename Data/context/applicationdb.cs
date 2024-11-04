using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotproject.Data.entity;
using dotproject.Migrations;
using Microsoft.EntityFrameworkCore;

namespace dotproject.Data.context
{
    public class applicationdb :DbContext
    {
        public applicationdb(DbContextOptions options):base(options){
               

        }  


        public DbSet<User > Users {get;set;}
         public DbSet<productEntity> products {get;set;}
    }
}