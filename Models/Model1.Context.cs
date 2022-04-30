﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication007.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBEntities3 : DbContext
    {
        public DBEntities3()
            : base("name=DBEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ItemMaster> ItemMasters { get; set; }
        public virtual DbSet<ModuleDetail> ModuleDetails { get; set; }
        public virtual DbSet<ModuleRolePermission> ModuleRolePermissions { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PO_Detail> PO_Detail { get; set; }
        public virtual DbSet<PO_WIP> PO_WIP { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shipment_Detail> Shipment_Detail { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    
        public virtual ObjectResult<Nullable<int>> USERLOGIN(string uSER, string pASS)
        {
            var uSERParameter = uSER != null ?
                new ObjectParameter("USER", uSER) :
                new ObjectParameter("USER", typeof(string));
    
            var pASSParameter = pASS != null ?
                new ObjectParameter("PASS", pASS) :
                new ObjectParameter("PASS", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("USERLOGIN", uSERParameter, pASSParameter);
        }
    
        public virtual ObjectResult<SP_RolePermission_Result> SP_RolePermission(string roleID, string moduleID)
        {
            var roleIDParameter = roleID != null ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(string));
    
            var moduleIDParameter = moduleID != null ?
                new ObjectParameter("ModuleID", moduleID) :
                new ObjectParameter("ModuleID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_RolePermission_Result>("SP_RolePermission", roleIDParameter, moduleIDParameter);
        }
    }
}
