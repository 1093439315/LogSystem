using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 分页组件
    /// </summary>
    public class Pagination
    {
        public Pagination()
        {
            IsPaging = true;
        }

        private int _PageSize = 30;
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize
        {
            get { return _PageSize; }
            set
            {
                if (value < 1) value = 1;
                _PageSize = value;
            }
        }
        private int _PageIndex = 1;
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get { return _PageIndex; }
            set
            {
                if (value < 1) value = 1;
                _PageIndex = value;
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (DataCount == 0) return 1;
                decimal cou = (decimal)DataCount / PageSize;
                var count = Math.Ceiling(cou);
                return Convert.ToInt32(Math.Ceiling(cou));
            }
        }
        /// <summary>
        /// 数据总量
        /// </summary>
        public long DataCount { get; set; }

        public int Take
        {
            get { return this.PageSize; }
        }
        public int Skip
        {
            get { return PageSize * (PageIndex - 1); }
        }
        /// <summary>
        /// 是否分页
        /// </summary>
        public bool IsPaging { get; set; }
    }
}
