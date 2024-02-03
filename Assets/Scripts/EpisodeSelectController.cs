// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;
using UnityEngine.UI;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ������ ���������� ������� � ���� ������ ��������.
    /// </summary>
    public class EpisodeSelectController : MonoBehaviour
    {
        #region Parameters

        [SerializeField] private Episode episode;

        [SerializeField] private TextMeshProUGUI episodeNickname;

        [SerializeField] private Image previewImage;

        #endregion

        #region API



        #region Unity API

        /// <summary>
        /// �������������� ������ �� �������.
        /// </summary>
        private void Start()
        {
            if (episodeNickname != null)
                episodeNickname.text = episode.EpisodeName;

            if (previewImage != null)
                previewImage.sprite = episode.PreviewImage;
        }

        #endregion

        #region Public API

        /// <summary>
        /// ����������� ��� ������� �� ������ "�����".
        /// </summary>
        public void OnStartEpisodeButtonClicked()
        {
            LevelSequenceController.Instance.StartEpisode(episode);
        }

        #endregion

        #endregion
    }
}