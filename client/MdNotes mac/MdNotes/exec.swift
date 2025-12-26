import Foundation
import Ink

struct Node: Codable, Hashable {
    let local_id: Int
    let global_id: Int
    var name: String
    var naiyou: String?
    
    var revison: Int
    var is_shared: Bool
    var dirty: Bool
    var is_deleted: Bool
    
    let created_at: Date
    var updated_at: Date
    
    func return_html() -> String {
        guard let md = naiyou, !md.isEmpty else { return "" }
        let parser = MarkdownParser()
        return parser.html(from: md)
    }

    init(local_id: Int,
         global_id: Int,
         name: String,
         naiyou: String? = nil,
         revison: Int = 0,
         is_shared: Bool = false,
         dirty: Bool = false,
         is_deleted: Bool = false,
         created_at: Date = Date(),
         updated_at: Date = Date()) {
        self.local_id = local_id
        self.global_id = global_id
        self.name = name
        self.naiyou = naiyou
        self.revison = revison
        self.is_shared = is_shared
        self.dirty = dirty
        self.is_deleted = is_deleted
        self.created_at = created_at
        self.updated_at = updated_at
    }
}
