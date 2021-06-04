using RainesGames.Combat.States;
using RainesGames.Combat.States.StateGraphs.PreemptiveStrike;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CombatStateManager))]
public class AddCombatState : Editor
{
    string _stateName;
    bool _createCellEventHandlers;
    bool _createUnitEventHandlers;
    bool _createValidators;
    Type _stateGraph = typeof(PreemptiveStrikeGraph);  // Hardcoded for now, until new graphs are added
    Type[] _validatorStates;
    Dictionary<Type, bool> _validatorStateToggles;
    string _scriptBasePath;

    const string TEMPLATE_BASE_PATH = "Assets/Scripts/Editor/CombatStateManager/";

    const string CELL_EVENT_HANDLER_INIT_FLAG = "###CELL_EVENT_HANDLER_INIT###";
    const string STATE_GRAPH_NAME_FLAG = "###STATE_GRAPH_NAME###";
    const string STATE_GRAPH_NAME_SUB_FLAG = "###STATE_GRAPH_NAME_SUB###";
    const string STATE_NAME_CAMEL_FLAG = "###STATE_NAME_CAMEL###";
    const string STATE_NAME_FLAG = "###STATE_NAME###";
    const string STATE_NAME_STRING_FLAG = "###STATE_NAME_STRING###";
    const string TRANSITION_STATE_NAME_FLAG = "###TRANSITION_STATE_NAME###";
    const string TRANSITION_STATE_NAME_SUB_FLAG = "###TRANSITION_STATE_NAME_SUB###";
    const string TRANSITION_STATE_USING_FLAG = "###TRANSITION_STATE_USING###";
    const string TRANSITION_STATE_VALIDATE_CHECK_FLAG = "###TRANSITION_STATE_VALIDATE_CHECK###";
    const string TRANSITION_STATE_VALIDATE_FLAG = "###TRANSITION_STATE_VALIDATE###";
    const string UNIT_EVENT_HANDLER_INIT_FLAG = "###UNIT_EVENT_HANDLER_INIT###";

    void OnEnable()
    {
        CombatStateManager manager = (CombatStateManager)target;

        _validatorStates = new Type[]
        {
            manager.BattleStart.GetType(),
            manager.PlayerPlacement.GetType(),
            manager.EnemyPlacement.GetType(),
            manager.PlayerTurn.GetType()
        };

        _validatorStateToggles = new Dictionary<Type, bool>
        {
            { manager.BattleStart.GetType(), false },
            { manager.PlayerPlacement.GetType(), false },
            { manager.EnemyPlacement.GetType(), false },
            { manager.PlayerTurn.GetType(), false }
        };

        _scriptBasePath = "Assets/Scripts/Combat/States";
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUIContent content = new GUIContent()
        {
            text = "Add a new combat state"
        };

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField(content);

        content.text = "State name (Pascal case)";
        EditorGUILayout.BeginHorizontal();
        _stateName = EditorGUILayout.TextField(content, _stateName);
        EditorGUILayout.EndHorizontal();

        content.text = "Create Cell event objects";
        _createCellEventHandlers = EditorGUILayout.Toggle(content, _createCellEventHandlers);

        content.text = "Create Unit event objects";
        _createUnitEventHandlers = EditorGUILayout.Toggle(content, _createUnitEventHandlers);

        content.text = "Create transition validators";
        EditorGUILayout.Separator();
        _createValidators = EditorGUILayout.BeginToggleGroup(content, _createValidators);
        
        content.text = "Transition validator states";
        
        foreach(Type type in _validatorStates)
        {
            content.text = type.Name;
            _validatorStateToggles[type] = EditorGUILayout.Toggle(content, _validatorStateToggles[type]);
        }

        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();

        if(GUILayout.Button("Submit"))
            OnSubmit();

        if(GUILayout.Button("Reset"))
            OnReset();

        EditorGUILayout.EndHorizontal();
    }

    void OnReset()
    {
        _stateName = "";
        _createCellEventHandlers = false;
        _createUnitEventHandlers = false;
        _createValidators = false;

        foreach(Type type in _validatorStates)
        {
            _validatorStateToggles[type] = false;
        }
    }

    void OnSubmit()
    {
        WriteState();
        WriteCellEventHandler();
        WriteUnitEventHandler();
        WriteValidator();

        Debug.Log("Created state " + _stateName);
        Debug.Log("Remember to add the new state to the StateManager/StateGraph!");
    }

    string ToCamel(string s)
    {
        return s[0].ToString().ToLower() + s.Substring(1);
    }

    string SplitOnCaps(string s)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach(char c in s)
        {
            if(Char.IsUpper(c))
                stringBuilder.Append(" ");

            stringBuilder.Append(c);
        }

        if(s != null && s.Length > 0 && Char.IsUpper(s[0]))
            stringBuilder.Remove(0, 1);

        return stringBuilder.ToString();
    }

    Dictionary<string, Dictionary<string, string>> GetTransitionStateStrings()
    {
        Dictionary<string, Dictionary<string, string>> transitionStates = new Dictionary<string, Dictionary<string, string>>();

        foreach(KeyValuePair<Type, bool> transitionStateBool in _validatorStateToggles)
        {
            if(transitionStateBool.Value)
                transitionStates.Add(transitionStateBool.Key.Name, new Dictionary<string, string>());
        }

        return transitionStates;
    }

    void WriteFile(string templatePath, string scriptPath, Dictionary<string, string> replacements)
    {
        TextAsset template = AssetDatabase.LoadAssetAtPath(templatePath, typeof(TextAsset)) as TextAsset;

        if(template == null)
            Debug.LogError("Can't find template file '" + templatePath + "'");

        string contents = template.text;

        foreach(KeyValuePair<string, string> replacement in replacements)
            contents = contents.Replace(replacement.Key, replacement.Value);

        StreamWriter writer = new StreamWriter(scriptPath);
        writer.Write(contents);
        writer.Close();

        AssetDatabase.ImportAsset(scriptPath);
        AssetDatabase.Refresh();
    }

    void WriteState()
    {
        if(AssetDatabase.CreateFolder(_scriptBasePath, _stateName) == "")
            throw new DirectoryNotFoundException("Could not create directory " + _scriptBasePath + _stateName);

        string templatePath = TEMPLATE_BASE_PATH + "StateTemplate.txt";
        string scriptPath = _scriptBasePath + "/" + _stateName + "/" + _stateName + "State.cs";
        
        Dictionary<string, string> replacements = new Dictionary<string, string>()
        {
            { CELL_EVENT_HANDLER_INIT_FLAG, _createCellEventHandlers ? "_cellEventHandler = new CellEventHandler(this);" : "" },
            { STATE_NAME_FLAG, _stateName },
            { STATE_NAME_STRING_FLAG, SplitOnCaps(_stateName) },
            { UNIT_EVENT_HANDLER_INIT_FLAG, _createUnitEventHandlers ? "_unitEventHandler = new UnitEventHandler(this);" : "" }
        };

        WriteFile(templatePath, scriptPath, replacements);
    }

    void WriteEventHandler(string filename)
    {
        string templatePath = TEMPLATE_BASE_PATH + filename + "Template.txt";
        string scriptPath = _scriptBasePath + "/" + _stateName + "/" + filename + ".cs";

        Dictionary<string, string> replacements = new Dictionary<string, string>()
        {
            { STATE_NAME_CAMEL_FLAG, ToCamel(_stateName) },
            { STATE_NAME_FLAG, _stateName }
        };

        WriteFile(templatePath, scriptPath, replacements);
    }

    void WriteCellEventHandler()
    {
        if(_createCellEventHandlers)
            WriteEventHandler("CellEventHandler");
    }

    void WriteUnitEventHandler()
    {
        if(_createUnitEventHandlers)
            WriteEventHandler("UnitEventHandler");
    }

    void WriteValidator()
    {
        if(!_createValidators)
            return;

        string validatorPath = _scriptBasePath + "/StateGraphs/" + SubStringMinusFive(_stateGraph.Name) + "/TransitionValidators";

        if(AssetDatabase.CreateFolder(validatorPath, _stateName) == "")
            throw new DirectoryNotFoundException("Could not create directory " + validatorPath + "/" + _stateName);

        string templatePath = TEMPLATE_BASE_PATH + "ValidatorTemplate.txt";
        string scriptPath = _scriptBasePath + "/StateGraphs/" + SubStringMinusFive(_stateGraph.Name) + "/TransitionValidators/" + _stateName + "/Validator.cs";
        string nl = Environment.NewLine;
        string transitionStateUsingPartial = "using RainesGames.Combat.States.###TRANSITION_STATE_NAME_SUB###;";
        string transitionStateValidateCheckPartial = "\t\t\tif(nextState.GetType() == typeof(###TRANSITION_STATE_NAME###))" + nl + "\t\t\t\treturn ###TRANSITION_STATE_NAME_SUB###();" + nl;
        string transitionStateValidatePartial = "\t\tbool ###TRANSITION_STATE_NAME_SUB###() { return true; }";
        Dictionary<string, Dictionary<string, string>> transitionStates = GetTransitionStateStrings();

        Dictionary<string, string> replacements = new Dictionary<string, string>()
        {
            { STATE_GRAPH_NAME_FLAG, _stateGraph.Name },
            { STATE_GRAPH_NAME_SUB_FLAG, SubStringMinusFive(_stateGraph.Name) },
            { STATE_NAME_FLAG, _stateName }
        };

        foreach(KeyValuePair<string, Dictionary<string, string>> transitionState in transitionStates)
        {
            transitionState.Value.Add(TRANSITION_STATE_NAME_FLAG, transitionState.Key);
            transitionState.Value.Add(TRANSITION_STATE_NAME_SUB_FLAG, SubStringMinusFive(transitionState.Key));
        }

        string replacement = GetMultiReplacement(transitionStateUsingPartial, transitionStates);
        replacements.Add(TRANSITION_STATE_USING_FLAG, replacement);

        replacement = GetMultiReplacement(transitionStateValidateCheckPartial, transitionStates);
        replacements.Add(TRANSITION_STATE_VALIDATE_CHECK_FLAG, replacement);

        replacement = GetMultiReplacement(transitionStateValidatePartial, transitionStates);
        replacements.Add(TRANSITION_STATE_VALIDATE_FLAG, replacement);

        WriteFile(templatePath, scriptPath, replacements);
    }

    string GetMultiReplacement(string partial, Dictionary<string, Dictionary<string, string>> replacementData)
    {
        string multiReplacement = partial;
        int i = 0;

        foreach(KeyValuePair<string, Dictionary<string, string>> stateFlagAndReplacement in replacementData)
        {
            foreach(KeyValuePair<string, string> flagReplacementPair in stateFlagAndReplacement.Value)
                multiReplacement = multiReplacement.Replace(flagReplacementPair.Key, flagReplacementPair.Value);

            if(i < replacementData.Count - 1)
                multiReplacement += Environment.NewLine + partial;

            i++;
        }

        return multiReplacement;
    }

    string SubStringMinusFive(string stateName)
    {
        return stateName.Substring(0, stateName.Length - 5);
    }
}
