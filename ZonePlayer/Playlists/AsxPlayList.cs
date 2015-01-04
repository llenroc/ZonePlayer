﻿//---------------------------------------------------------------
// The MIT License. Beejones 
//---------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Diagnostics;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace ZonePlayer
{
    /// <summary>
    /// Implementation of <see cref="ZonePlaylist"/> for reading asx items
    /// </summary>
    [DataContract]
    public sealed class AsxPlayList : ZonePlaylist
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsxPlayList"/> class.
        /// </summary>
        public AsxPlayList()
        {
            this.CurrentItemIndex = 0;
            this.PlayList = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsxPlayList"/> class.
        /// </summary>
        /// <param name="list">List of playlist items</param>
        /// <param name="listName">Name of the playlist item</param>
        public AsxPlayList(List<IPlaylistItem> list, string listName = null)
            : this()
        {
            this.PlayList = (List<IPlaylistItem>)list;
            this.ListName = listName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsxPlayList"/> class.
        /// </summary>
        /// <param name="listUri">Uri to the item</param>
        /// <param name="listName">Name of the playlist item</param>
        /// <param name="randomize">True when playlist needs to be randomized</param>
        public AsxPlayList(Uri listUri, string listName = null, bool randomize = false)
            : this()
        {
            this.PlayList = this.Read(listUri, listName, randomize).PlayList;
            this.ListName = listName;
            this.ListUri = listUri;
            this.Randomized = randomize;
        }
        /// <summary>
        /// Gets whether the playlist is randomized
        /// </summary>
        public override bool Randomized
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the name of the playlist
        /// </summary>
        public override string ListName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the playlist
        /// </summary>
        public override Uri ListUri
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the <see cref="PlayerType"/> of the playlist
        /// The player type defines the component that will be used to render the item
        /// </summary>
        public override PlayerType PlayerType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the playlist list
        /// </summary>
        public override List<IPlaylistItem> PlayList
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets the <see cref="IPlaylistItem"/> to populate the playlist
        /// </summary>
        /// <param name="listUri">Uri to the item</param>
        /// <param name="listName">Name of the playlist item</param>
        /// <param name="randomize">True when playlist needs to be randomized</param>
        /// <returns>List of <see cref="IPlaylistItem"/> </returns>
        public override ZonePlaylist Read(Uri listUri, string listName, bool randomize)
        {
            this.ListUri = Checks.NotNull<Uri>("ListUri", listUri);
            List<IPlaylistItem> playList = (List<IPlaylistItem>)ReadPlayList(this.ListUri, randomize);
            return (ZonePlaylist)new AsxPlayList(playList, listName);
        }

        /// <summary>
        /// Read itms of playlist
        /// </summary>
        /// <param name="resource">The <see cref="Uri" to the resource/></param>
        /// <param name="randomize">True if the items in the playlist needs to be randomized</param>
        /// <returns></returns>
        private List<IPlaylistItem> ReadPlayList(Uri resource, bool randomize)
        {
            XDocument asx = OpenPlayList(resource);

            /*
            IEnumerable<XAttribute> xmlRefs =
                from record in asx.Descendants("REF")
                select record.Attribute("HREF");
            List<string> refs = xmlRefs.Select(r => r.Value).ToList();
            */
            IEnumerable<XElement> xmlEntry =
                from record in asx.Descendants("ENTRY")
                select record;

            List<IPlaylistItem> list = new List<IPlaylistItem>();
            foreach(var entry in xmlEntry)
            {
                string title = 
                    (from titleXml in entry.Descendants("TITLE")
                    select titleXml.Value).FirstOrDefault();

                string reference =
                    (from refXml in entry.Descendants("REF")
                     select refXml.Attribute("HREF").Value).FirstOrDefault();

                string banner =
                    (from refXml in entry.Descendants("BANNER")
                     select refXml.Attribute("HREF").Value).FirstOrDefault();

                Dictionary<string, string> param =
                    (from refXml in entry.Descendants("PARAM")
                     select new KeyValuePair<string, string>(refXml.Attribute("NAME").Value, refXml.Attribute("VALUE").Value))
                     .ToDictionary(x => x.Key, x => x.Value);

                AsxItem item = new AsxItem(title, new Uri(reference), PlayListType.asx, (banner != null) ? new Uri(banner) : null, param);
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// Open asx playlist in xDocument
        /// </summary>
        /// <param name="resource">The <see cref="Uri"/> of the resource</param>
        /// <returns>Reader to the stream</returns>
        private XDocument OpenPlayList(Uri resource)
        {
            Checks.NotNull<Uri>("resource", resource);
            Log.Item(EventLogEntryType.Information, "Open item: ", resource.ToString());

            XDocument doc = XDocument.Load(resource.ToString(), LoadOptions.None);
            return doc;
        }
    }
}
