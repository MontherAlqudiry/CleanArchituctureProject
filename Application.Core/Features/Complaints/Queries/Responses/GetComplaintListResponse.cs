﻿using Application.Data.Entities;

namespace Application.Core.Features.Complaints.Queries.Responses
{
    public class GetComplaintListResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string Description { get; set; }
        public string? File { get; set; }
        public string? Status { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }

    }
}
