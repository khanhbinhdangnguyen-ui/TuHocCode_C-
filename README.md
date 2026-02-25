# TuHocCode_C-

Unity desktop app học C++ offline theo mô hình mini-IDE.

## Mục tiêu v1
- Sidebar điều hướng: **Bài tập / Tài liệu / Điểm số**
- Vùng nội dung chính theo module
- Thanh trạng thái dưới cùng
- Nút ChatBot ở góc trái dưới, kéo-thả được, bấm để mở hộp thoại

## Cấu trúc thư mục đề xuất
Xem chi tiết tại `docs/unity-structure-plan.md`.

## Plugin mở rộng (mods)
Dự án có sẵn vùng plugin để thêm tính năng mà không phải sửa lõi:
- `Assets/Plugins/Mods/DocumentExtensions/`
- `Assets/Plugins/Mods/ChatProviders/`
- `Assets/Plugins/Mods/PracticeJudgers/`

Mỗi plugin có thể chứa:
- Assembly (.dll)
- Cấu hình `.json`
- Metadata (tên plugin, phiên bản, khả năng hỗ trợ)
