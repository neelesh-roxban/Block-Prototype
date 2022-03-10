using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Block),false)]
[CanEditMultipleObjects]
[System.Serializable]
public class BlockDrawer : Editor
{
    private Block blockInstance => target as Block;

    public override void OnInspectorGUI()
    {
       serializedObject.Update();
       ClearBoardButton();
       EditorGUILayout.Space();
       DrawColounmInputFields();
       EditorGUILayout.Space();

       if(blockInstance.board!=null && blockInstance.coloumns>0 && blockInstance.rows>0)
       {
           DrawBoardTable();
       }

       serializedObject.ApplyModifiedProperties();
       if(GUI.changed)
       {
           EditorUtility.SetDirty(blockInstance);
       }
    }

    private void ClearBoardButton()
    {
        if(GUILayout.Button("Clear Board"))
        {
            blockInstance.clear();
        }

    }
    private void DrawColounmInputFields()
    {
        var coloumnTemp = blockInstance.coloumns;
        var rowsTemp = blockInstance.rows;

        blockInstance.coloumns= EditorGUILayout.IntField("Columns", blockInstance.coloumns);
        blockInstance.rows = EditorGUILayout.IntField("Rows",blockInstance.rows);

        if((blockInstance.coloumns!=coloumnTemp||blockInstance.rows!=rowsTemp)&& blockInstance.coloumns>0 && blockInstance.rows>0)
        {
            blockInstance.CreateNewBoard();
        }

    }
    private void DrawBoardTable()
    {
        var tabelStyle = new GUIStyle("box");
        tabelStyle.padding = new RectOffset(10,10,10,10);
        tabelStyle.margin.left=32;

        var headerColoumnStyle = new GUIStyle();
        headerColoumnStyle.fixedWidth=65;
        headerColoumnStyle.alignment=TextAnchor.MiddleCenter;

        var rowStyle = new GUIStyle();
        rowStyle.fixedHeight=25;
        rowStyle.alignment= TextAnchor.MiddleCenter;

        var dataFieldStyle = new GUIStyle(EditorStyles.miniButtonMid);
        dataFieldStyle.normal.background = Texture2D.grayTexture;

        dataFieldStyle.onNormal.background= Texture2D.whiteTexture;

        for (var row=0; row <blockInstance.rows; row++)
        {
            EditorGUILayout.BeginHorizontal(headerColoumnStyle);

            for( var coloumn=0; coloumn<blockInstance.coloumns; coloumn++)
            {
                EditorGUILayout.BeginHorizontal(rowStyle);
                var data= EditorGUILayout.Toggle(blockInstance.board[row].coloumn[coloumn], dataFieldStyle);
                blockInstance.board[row].coloumn[coloumn] = data;

                EditorGUILayout.EndHorizontal();


            }

            EditorGUILayout.EndHorizontal();
        }
         

    }
}
