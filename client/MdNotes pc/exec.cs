using System;
using Markdig;

public class Node
{
	public int LocalId { get; }
	public int GlobalId { get; }
	public string Name { get; set; }
	public string? Naiyou { get; set; }

	public int Revison { get; set; }
	public bool IsShared { get; set; }
	public bool Dirty { get; set; }
	public bool IsDeleted { get; set; }

	public DateTime CreatedAt { get; }
	public DateTime UpdatedAt { get; set; }

	public Node(int localId,
				int globalId,
				string name,
				string? naiyou = null,
				int revison = 0,
				bool isShared = false,
				bool dirty = false,
				bool isDeleted = false,
				DateTime? createdAt = null,
				DateTime? updatedAt = null)
	{
		LocalId = localId;
		GlobalId = globalId;
		Name = name;
		Naiyou = naiyou;
		Revison = revison;
		IsShared = isShared;
		Dirty = dirty;
		IsDeleted = isDeleted;
		CreatedAt = createdAt ?? DateTime.UtcNow;
		UpdatedAt = updatedAt ?? DateTime.UtcNow;
	}

	public string ReturnHtml()
	{
		if (string.IsNullOrEmpty(Naiyou)) return string.Empty;
		var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
		return Markdown.ToHtml(Naiyou, pipeline);
	}
}

