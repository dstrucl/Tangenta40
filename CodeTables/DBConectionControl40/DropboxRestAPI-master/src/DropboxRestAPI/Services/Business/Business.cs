/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2014 Itay Sagui
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */


using DropboxRestAPI.RequestsGenerators;

namespace DropboxRestAPI.Services.Business
{
    public class Business : IBusiness
    {
        public Business(IRequestExecuter requestExecuter, IRequestGenerator requestGenerator)
        {
            Info = new Info(requestExecuter, requestGenerator.Business.TeamInfo);
            Members = new Members(requestExecuter, requestGenerator.Business.TeamMembers);
            Reports = new Reports(requestExecuter, requestGenerator.Business.Reports);
            AuditLog = new AuditLog(requestExecuter, requestGenerator.Business.AuditLog);
            Groups = new Groups(requestExecuter, requestGenerator.Business.Groups);
        }

        public IInfo Info { get; set; }
        public IMembers Members { get; set; }
        public IReports Reports { get; set; }
        public IAuditLog AuditLog { get; set; }
        public IGroups Groups { get; set; }
    }
}