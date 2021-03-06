﻿using Common;
using Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using Linq = MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Core
{
    public static class DbProvider
    {
        private static IMongoDatabase IMongoDatabase
        {
            get
            {
                var connStr = Config.MongoDbConnStr;
                var mongoUrl = new MongoUrlBuilder(connStr);

                // 获取数据库名称
                string databaseName = mongoUrl.DatabaseName;

                // 创建并实例化客户端
                var _client = new MongoClient(mongoUrl.ToMongoUrl());

                //  根据数据库名称实例化数据库
                return _client.GetDatabase(databaseName);
            }
        }

        public static IMongoCollection<T> Collection<T>()
        {
            var co = IMongoDatabase.GetCollection<T>(typeof(T).Name);
            return co;
        }

        public static Linq.IMongoQueryable<T> Queryable<T>()
            where T : class
        {
            var qu = IMongoDatabase.GetCollection<T>(typeof(T).Name).AsQueryable();
            return qu;
        }

        #region 插入

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="dbName">数据名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="model">数据对象</param>
        public static void Insert<T>(T model)
            where T : BaseEntity
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "待插入数据不能为空");
            var collection = IMongoDatabase.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(model);
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="dbName">数据名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="models">数据对象</param>
        public static void Insert<T>(List<T> models)
            where T : BaseEntity
        {
            if (models == null)
                throw new ArgumentNullException(nameof(models), "待插入数据不能为空");
            var collection = IMongoDatabase.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(models);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 根据ID获取数据对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="id">ID</param>
        /// <returns>数据对象</returns>
        public static T GetById<T>(string id)
            where T : BaseEntity
        {
            var collection = IMongoDatabase.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(id));
            return collection.Find(filter).SingleOrDefault();
        }

        /// <summary>
        /// 根据ID获取数据对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <param name="id">ID</param>
        /// <returns>数据对象</returns>
        public static T GetById<T>(ObjectId id)
            where T : BaseEntity
        {
            var collection = IMongoDatabase.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).SingleOrDefault();
        }

        #endregion

        #region 删除

        public static void DeleteById<T>(string id)
        {
            var collection = IMongoDatabase.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(id));
            collection.DeleteOne(filter);
        }

        public static void DeleteByIds<T>(List<string> ids)
        {
            if (ids == null || ids.Count == 0) return;
            var collection = IMongoDatabase.GetCollection<T>(typeof(T).Name);
            var objIds = new List<ObjectId>();
            ids.ForEach(a => objIds.Add(new ObjectId(a)));
            var filter = Builders<T>.Filter.In("Id", objIds);
            collection.DeleteMany(filter);
        }

        #endregion
    }
}
