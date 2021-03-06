﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using VRage.Collections;

namespace VRage.Groups
{
    partial class MyGroups<TNode, TGroupData>
        where TGroupData : IGroupData<TNode>, new()
        where TNode : class
    {
        // Internal members starting with 'm_' are for internal use only, there's no friends in c#
        public class Node
        {
            Group m_currentGroup;

            internal TNode m_node;
            internal Group m_group
            {
                get { return m_currentGroup; }
                set
                {
                    Debug.Assert(m_currentGroup != value, "Setting group which is already set");
                    if (m_currentGroup != null)
                        m_currentGroup.GroupData.OnNodeRemoved(m_node);
                    m_currentGroup = value;
                    if (m_currentGroup != null)
                        m_currentGroup.GroupData.OnNodeAdded(m_node);
                }
            }

            internal Dictionary<long, Node> m_children = new Dictionary<long, Node>();
            internal Dictionary<long, Node> m_parents = new Dictionary<long, Node>();

            public int LinkCount { get { return m_children.Count + m_parents.Count; } }
            public TNode NodeData { get { return m_node; } }
            public Group Group { get { return m_group; } }

            public DictionaryValuesReader<long, Node> Children
            {
                get { return new DictionaryValuesReader<long, Node>(m_children); }
            }

            public override string ToString()
            {
                return m_node.ToString();
            }
        }

        // Internal members starting with 'm_' are for internal use only, there's no friends in c#
        public class Group
        {
            internal HashSet<Node> m_members = new HashSet<Node>();

            public readonly TGroupData GroupData = new TGroupData();

            public HashSetReader<Node> Nodes
            {
                get { return new HashSetReader<Node>(m_members); }
            }
        }
    }
}
