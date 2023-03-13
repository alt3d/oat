using System.Collections.Generic;

namespace OpenAIToolkit
{
    internal class DtoConverter
    {
        public List<Model> Convert(List<ModelDto> dto)
        {
            if (dto == null)
                return null;

            var result = new List<Model>();
            foreach (var modelDto in dto)
            {
                var model = Convert(modelDto);
                if (model != null)
                    result.Add(model);
            }

            return result;
        }

        public Model Convert(ModelDto dto)
        {
            var model = new Model {
                Id = dto.id,
                Created = dto.created,
                OwnedBy = dto.owned_by,
                Permissions = Convert(dto.permission),
                Root = dto.root,
                Parent = dto.parent
            };

            return model;
        }

        private List<Permission> Convert(List<PermissionDto> dto)
        {
            if (dto == null)
                return null;

            var result = new List<Permission>();
            foreach (var permissionDto in dto)
            {
                var permission = Convert(permissionDto);
                if (permission != null)
                    result.Add(permission);
            }

            return result;
        }

        private Permission Convert(PermissionDto dto)
        {
            if (dto == null)
                return null;

            return new Permission {
                Id = dto.id,
                Created = dto.created,
                AllowCreateEngine = dto.allow_create_engine,
                AllowSampling = dto.allow_sampling,
                AllowLogprobs = dto.allow_logprobs,
                AllowSearchIndices = dto.allow_search_indices,
                AllowView = dto.allow_view,
                AllowFineTuning = dto.allow_fine_tuning,
                Organization = dto.organization,
                IsBlocking = dto.is_blocking
            };
        }

        public List<Choice> Convert(List<ChoiceDto> dto)
        {
            if (dto == null)
                return null;

            var result = new List<Choice>();
            foreach (var choiceDto in dto)
            {
                var choice = Convert(choiceDto);
                if (choice != null)
                    result.Add(choice);
            }

            return result;
        }

        private Choice Convert(ChoiceDto dto)
        {
            if (dto == null)
                return null;

            var result = new Choice {
                Text = dto.text.Trim(),
                LogProbs = Convert(dto.logprobs),
                FinishReason = dto.finish_reason,
                Index = dto.index
            };

            return result;
        }

        private LogProbs Convert(LogProbsDto dto)
        {
            if (dto == null)
                return null;

            return new LogProbs {
                Tokens = dto.tokens,
                TokenLogProbs = dto.token_logprobs,
                TextOffset = dto.text_offset,
                TopLogProbs = dto.top_logprobs
            };
        }

        public Usage Convert(UsageDto dto)
        {
            if (dto == null)
                return null;

            return new Usage {
                PromptTokens = dto.prompt_tokens,
                CompletionTokens = dto.completion_tokens,
                TotalTokens = dto.total_tokens
            };
        }

        public List<ImageData> Convert(List<ImageDataDto> dto)
        {
            if (dto == null)
                return null;

            var result = new List<ImageData>();
            foreach (var dataDto in dto)
            {
                var imageData = Convert(dataDto);
                if (imageData != null)
                    result.Add(imageData);
            }

            return result;
        }

        private ImageData Convert(ImageDataDto dto)
        {
            if (dto == null)
                return null;

            return new ImageData {
                Url = dto.url
            };
        }

        public List<ChatMessageDto> Convert(List<ChatMessage> messages)
        {
            var result = new List<ChatMessageDto>();
            for (var i = 0; i < messages.Count; i++)
            {
                var dto = new ChatMessageDto {
                    role = messages[i].Role.GetStringValue(),
                    content = messages[i].Content
                };
                result.Add(dto);
            }

            return result;
        }

        public List<ChatChoice> Convert(List<ChatChoiceDto> choiceDto)
        {
            var result = new List<ChatChoice>();
            for (var i = 0; i < choiceDto.Count; i++)
            {
                var dto = choiceDto[i];
                var choice = new ChatChoice {
                    Message = new ChatMessage {
                        Role = dto.message.ParseRole(),
                        Content = dto.message.content.Trim()
                    },
                    Index = dto.index,
                    FinishReason = dto.finish_reason
                };
                result.Add(choice);
            }

            return result;
        }

        public List<ModerationResult> Convert(List<ModerationResultDto> dtoResults)
        {
            var result = new List<ModerationResult>();

            foreach (var dto in dtoResults)
            {
                var categoriesDto = dto.categories;
                var scoresDto = dto.category_scores;

                var moderationResult = new ModerationResult {
                    Categories = new ModerationCategories {
                        Hate = categoriesDto.hate,
                        HateThreatening = categoriesDto.hatethreatening,
                        SelfHarm = categoriesDto.hatethreatening,
                        Sexual = categoriesDto.sexual,
                        SexualMinors = categoriesDto.sexualminors,
                        Violence = categoriesDto.violence,
                        ViolenceGraphic = categoriesDto.violencegraphic
                    },
                    CategoryScores = new ModerationCategoryScores {
                        Hate = scoresDto.hate,
                        HateThreatening = scoresDto.hatethreatening,
                        SelfHarm = scoresDto.selfharm,
                        Sexual = scoresDto.sexual,
                        SexualMinors = scoresDto.sexualminors,
                        Violence = scoresDto.violence,
                        ViolenceGraphic = scoresDto.violencegraphic
                    },
                    Flagged = dto.flagged
                };

                result.Add(moderationResult);
            }

            return result;
        }
    }
}