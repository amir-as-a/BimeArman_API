namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BlogComment : BaseLocalizedExtendedEntity
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public bool ConfirmedByAdmin { get; set; }

	public string Comment { get; set; }

	public int BlogPostId { get; set; }

	public BlogPost BlogPost { get; set; }
}
