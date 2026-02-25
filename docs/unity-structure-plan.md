# Unity Structure Plan (Clean + Scalable)

## 1) Folder tree

```text
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── Models/
│   │   ├── Interfaces/
│   │   └── Utils/
│   ├── Services/
│   ├── Repositories/
│   ├── Features/
│   │   ├── Document/
│   │   ├── Chat/
│   │   ├── Practice/
│   │   └── Score/
│   └── App/
├── UI/
│   ├── UXML/
│   └── USS/
├── StreamingAssets/
│   └── Data/
│       ├── Documents/
│       │   ├── index.json
│       │   └── commands/
│       ├── Exercises/
│       ├── Synonyms/
│       └── Score/
└── Plugins/
    ├── Windows/mingw/
    └── Mods/
        ├── DocumentExtensions/
        ├── ChatProviders/
        └── PracticeJudgers/
```

## 2) Vai trò từng nhóm

- `Scripts/Core`: code thuần C# (model/interface/helper)
- `Scripts/Services`: business logic (search, chat, compile, grading, score)
- `Scripts/Repositories`: đọc JSON và hệ thống file
- `Scripts/Features`: controller từng màn hình
- `UI`: chứa UXML/USS riêng, không trộn trong `Scripts`
- `StreamingAssets/Data`: dữ liệu runtime số lượng lớn
- `Plugins/Windows/mingw`: công cụ biên dịch C++
- `Plugins/Mods`: plugin mở rộng tính năng theo từng miền

## 3) Chuẩn tài liệu cho ChatBot (mỗi lệnh một file)

Ví dụ `Assets/StreamingAssets/Data/Documents/commands/int.json`:

```json
{
  "id": "cmd_int",
  "command": "int",
  "title": "Lệnh int trong C++",
  "content": {
    "what_it_does": "int dùng để khai báo biến kiểu số nguyên.",
    "origin": "int kế thừa từ C và là kiểu nguyên thủy trong C++.",
    "examples": [
      {
        "title": "Ví dụ 1",
        "code": "int a = 10;\\ncout << a;"
      },
      {
        "title": "Ví dụ 2",
        "code": "int x = 3, y = 7;\\ncout << x + y;"
      }
    ],
    "combinations": [
      "const int MAX = 100;",
      "unsigned int n = 42;",
      "for (int i = 0; i < 10; i++)"
    ],
    "notes": [
      "Có thể tràn số nếu vượt phạm vi int."
    ],
    "avoid_when": [
      "Không dùng int cho số thực.",
      "Không dùng khi chắc chắn vượt giới hạn int."
    ],
    "use_when": [
      "Dùng cho số nguyên thông thường.",
      "Dùng cho biến đếm vòng lặp."
    ],
    "popularity": {
      "score": 98,
      "level": "Rất phổ biến"
    }
  },
  "tags": ["int", "so nguyen", "cpp basic"],
  "related_commands": ["long", "unsigned", "for"]
}
```

## 4) Chỉ mục tài liệu

`Assets/StreamingAssets/Data/Documents/index.json` nên lưu metadata nhẹ:
- id
- command
- title
- tags
- difficulty
- file

Giúp app load danh sách nhanh và chỉ mở file chi tiết khi người dùng chọn.

## 5) Plugin/mod contract (đề xuất)

Mỗi plugin nằm trong thư mục riêng, ví dụ:

`Assets/Plugins/Mods/DocumentExtensions/DocRankerV1/`

Chứa tối thiểu:
- `plugin.json`
- file nhị phân `.dll` (nếu có)

Mẫu `plugin.json`:

```json
{
  "id": "doc.ranker.v1",
  "name": "Document Ranker",
  "version": "1.0.0",
  "target": "DocumentExtensions",
  "entry": "DocRanker.EntryPoint",
  "description": "Tăng chất lượng xếp hạng tài liệu theo tag và độ khó.",
  "enabled": true
}
```
