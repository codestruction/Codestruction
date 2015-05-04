using System;
using System.Collections.Generic;
using System.Text;
using Codestruction.Infrastructure;
using Examine;
using Umbraco.Web;
using Umbraco.Web.Media.EmbedProviders.Settings;

namespace Codestruction.Web
{
    public class CodestructionApp: UmbracoApplication
    {
       
            protected override void OnApplicationStarted(object sender, EventArgs e)
            {
                base.OnApplicationStarted(sender, e);

                Bootstrap.Init();



                ExamineManager.Instance.IndexProviderCollection["ContentIndexer"].GatheringNodeData += ExamineEvents_GatheringNodeData;
            
        }
 
      
        void ExamineEvents_GatheringNodeData(object sender, IndexingNodeDataEventArgs e)
        {
            AddToContentsField(e);
        }
 
        /// <summary>
        /// munge into one field
        /// </summary>
        /// <param name="e"></param>
        private void AddToContentsField(IndexingNodeDataEventArgs e)
        {
            //var publishedContent = UmbracoContext.Current.ContentCache.GetById(e.NodeId);

            //if (publishedContent != null)
            //{
            //    e.Fields.Add("url", publishedContent.Url);
            //}

            //var combinedFields = new StringBuilder();

            var fields = new Dictionary<string, string>();
            foreach (var keyValuePair in e.Fields)
            {
                if (keyValuePair.Key.Equals("tags"))
                {
                    fields.Add("tags_tokenized",(keyValuePair.Value.TokenizeIndex()));
                }
                if (keyValuePair.Key.Equals("authors"))
                {
                    fields.Add("authors_tokenized",keyValuePair.Value.TokenizeIndex());
                }
            }
            foreach (var f in fields)
            {
                e.Fields.Add(f.Key, f.Value);
            }


        }

            
      
    }
}