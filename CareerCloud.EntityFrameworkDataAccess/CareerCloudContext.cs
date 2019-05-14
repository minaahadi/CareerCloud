using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
   public class CareerCloudContext: DbContext {
     
       public CareerCloudContext():base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
       {
            Database.Log = l => System.Diagnostics.Debug.WriteLine(l);
            //Configuration.ProxyCreationEnabled = createProxy;
       }
        
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyDescriptionPoco>().HasRequired(c => c.CompanyProfile)
                .WithMany(c => c.CompanyDescriptions).HasForeignKey(c => c.Company);
            modelBuilder.Entity<CompanyDescriptionPoco>().Ignore(o=>o.TimeStamp).HasRequired(s => s.SystemLanguageCode)
                .WithMany(c => c.CompanyDescriptions).HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<CompanyProfilePoco>().Ignore(o=>o.TimeStamp).HasMany(c => c.CompanyJobs).WithRequired(c => c.CompanyProfile)
                .HasForeignKey(c => c.Company);
            modelBuilder.Entity<CompanyProfilePoco>().HasMany(c => c.CompanyLocations)
                .WithRequired(c => c.CompanyProfile).HasForeignKey(c => c.Company);
            modelBuilder.Entity<CompanyJobPoco>().Ignore(o=>o.TimeStamp).HasMany(c => c.CompanyJobDescriptions).WithRequired(c => c.CompanyJob)
                .HasForeignKey(c => c.Job);
            modelBuilder.Entity<CompanyJobPoco>().HasMany(c => c.CompanyJobSkills).WithRequired(c => c.CompanyJob)
                .HasForeignKey(c => c.Job);
            modelBuilder.Entity<CompanyJobPoco>().HasMany(c => c.CompanyJobEducations).WithRequired(c => c.CompanyJob)
                .HasForeignKey(c => c.Job);
            modelBuilder.Entity<SecurityLoginPoco>().Ignore(o=>o.TimeStamp).HasMany(s => s.SecurityLoginsRole)
                .WithRequired(s => s.SecurityLogin).HasForeignKey(s => s.Login);
            modelBuilder.Entity<SecurityLoginPoco>().HasMany(s => s.SecurityLoginsLog)
                .WithRequired(s => s.SecurityLogin).HasForeignKey(s => s.Login);
            modelBuilder.Entity<SecurityRolePoco>().HasMany(s => s.SecurityLoginRole).WithRequired(s => s.SecurityRole)
                .HasForeignKey(s => s.Role);
            

            modelBuilder.Entity<ApplicantEducationPoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<ApplicantJobApplicationPoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<ApplicantProfilePoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<ApplicantSkillPoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().Ignore(o => o.TimeStamp);
           // modelBuilder.Entity<CompanyDescriptionPoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<CompanyJobDescriptionPoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<CompanyJobEducationPoco>().Ignore(o => o.TimeStamp);
            //modelBuilder.Entity<CompanyJobPoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<CompanyJobSkillPoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<CompanyLocationPoco>().Ignore(o => o.TimeStamp);
            //modelBuilder.Entity<CompanyProfilePoco>().Ignore(o => o.TimeStamp);
            //modelBuilder.Entity<SecurityLoginPoco>().Ignore(o => o.TimeStamp);
            modelBuilder.Entity<SecurityLoginsRolePoco>().Ignore(o => o.TimeStamp);
           


        }
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
       public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
       public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
       public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
       public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
       public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
       public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
       public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
       public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }
       public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
       public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
       public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
       public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
       public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
       public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
       public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
       public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
       public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
       public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

       
    }
}

