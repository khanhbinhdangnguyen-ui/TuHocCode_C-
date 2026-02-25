using System;
using System.Collections.Generic;
using System.Linq;
using TuHocCode.Core.Models;
using TuHocCode.Repositories;

namespace TuHocCode.Services
{
    public class ChatService
    {
        private readonly DocumentRepository _documentRepository = new DocumentRepository();

        public ChatAnswer Ask(string question)
        {
            var query = (question ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                return new ChatAnswer { title = "ChatBot", summary = "Bạn hãy nhập câu hỏi về lệnh C++.", relatedCommands = Array.Empty<string>() };
            }

            var best = _documentRepository.Search(query).FirstOrDefault();
            if (best == null)
            {
                return new ChatAnswer { title = "ChatBot", summary = "Mình chưa tìm thấy thông tin phù hợp trong tài liệu nội bộ.", relatedCommands = Array.Empty<string>() };
            }

            var doc = _documentRepository.LoadByRelativePath(best.file);
            return BuildAnswer(doc);
        }

        private static ChatAnswer BuildAnswer(CommandDocument doc)
        {
            var firstExample = doc.content?.examples?.FirstOrDefault();
            var summaryParts = new List<string>();

            if (!string.IsNullOrWhiteSpace(doc.content?.what_it_does))
            {
                summaryParts.Add(doc.content.what_it_does);
            }

            if (doc.content?.use_when != null && doc.content.use_when.Length > 0)
            {
                summaryParts.Add($"Nên dùng khi: {doc.content.use_when[0]}");
            }

            return new ChatAnswer
            {
                title = doc.title,
                summary = string.Join("\n", summaryParts),
                codeExample = firstExample?.code ?? string.Empty,
                relatedCommands = doc.related_commands ?? Array.Empty<string>()
            };
        }
    }
}
